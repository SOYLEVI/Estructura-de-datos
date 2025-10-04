using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace VuelosBaratos
{
    class Flight
    {
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Price { get; set; }
        public int DurationMin { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public override string ToString()
        {
            return $"{Id}: {From} -> {To} | ${Price} | Dur: {DurationMin} min | {Departure:yyyy-MM-dd HH:mm} -> {Arrival:yyyy-MM-dd HH:mm}";
        }
    }

    class FlightEdge
    {
        public string To { get; set; }
        public decimal Weight { get; set; } // price
        public string FlightId { get; set; }
    }

    class Program
    {
        static string dataFile = "flights.txt";

        static void Main(string[] args)
        {
            List<Flight> flights = LoadOrCreateSampleData(dataFile);
            var graph = BuildGraph(flights);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Encuentra Vuelos Baratos - Menú ===");
                Console.WriteLine("1) Listar vuelos");
                Console.WriteLine("2) Encontrar vuelo más barato (posible con conexiones)");
                Console.WriteLine("3) Añadir vuelo");
                Console.WriteLine("4) Mostrar estructura (reporte)");
                Console.WriteLine("5) Guardar y salir");
                Console.Write("Elija opción: ");
                var opt = Console.ReadLine();
                if (opt == "1")
                {
                    ListFlights(flights);
                    Pause();
                }
                else if (opt == "2")
                {
                    Console.Write("Origen: ");
                    var origen = Console.ReadLine();
                    Console.Write("Destino: ");
                    var destino = Console.ReadLine();
                    Console.Write("Máx. escalas (0 para directo, 1, 2...): ");
                    int maxStops = 1;
                    int.TryParse(Console.ReadLine(), out maxStops);

                    var sw = Stopwatch.StartNew();
                    var result = FindCheapestPath(graph, origen, destino, maxStops);
                    sw.Stop();

                    if (result == null)
                    {
                        Console.WriteLine("No se encontró ruta.");
                    }
                    else
                    {
                        Console.WriteLine($"Ruta más barata encontrada (precio total ${result.TotalPrice})");
                        foreach (var leg in result.Path)
                        {
                            var f = flights.FirstOrDefault(x => x.Id == leg);
                            if (f != null) Console.WriteLine($"  - {f}");
                        }
                    }
                    Console.WriteLine($"Tiempo de búsqueda: {sw.Elapsed.TotalMilliseconds:F2} ms");
                    Pause();
                }
                else if (opt == "3")
                {
                    AddFlightInteractive(flights, graph);
                    Pause();
                }
                else if (opt == "4")
                {
                    ShowReport(graph, flights);
                    Pause();
                }
                else if (opt == "5")
                {
                    SaveFlights(dataFile, flights);
                    Console.WriteLine("Guardado. Saliendo...");
                    break;
                }
            }
        }

        static List<Flight> LoadOrCreateSampleData(string path)
        {
            if (!File.Exists(path))
            {
                var sample = new[]
                {
                    "F1;Quito;Guayaquil;80;60;2025-10-15T09:00;2025-10-15T10:00",
                    "F2;Quito;Cuenca;100;80;2025-10-15T08:00;2025-10-15T09:20",
                    "F3;Cuenca;Guayaquil;50;50;2025-10-15T11:00;2025-10-15T11:50",
                    "F4;Quito;Guayaquil;120;55;2025-10-15T13:00;2025-10-15T13:55",
                    "F5;Quito;Lima;200;180;2025-10-15T07:00;2025-10-15T10:00",
                    "F6;Lima;Guayaquil;90;110;2025-10-15T12:00;2025-10-15T13:50",
                    "F7;Cuenca;Lima;140;150;2025-10-15T16:00;2025-10-15T18:30",
                    "F8;Guayaquil;Manta;60;50;2025-10-15T15:00;2025-10-15T15:50"
                };
                File.WriteAllLines(path, sample);
            }

            var lines = File.ReadAllLines(path);
            var list = new List<Flight>();
            foreach (var ln in lines)
            {
                if (string.IsNullOrWhiteSpace(ln)) continue;
                var parts = ln.Split(';');
                if (parts.Length < 7) continue;
                try
                {
                    list.Add(new Flight
                    {
                        Id = parts[0].Trim(),
                        From = parts[1].Trim(),
                        To = parts[2].Trim(),
                        Price = decimal.Parse(parts[3].Trim(), CultureInfo.InvariantCulture),
                        DurationMin = int.Parse(parts[4].Trim()),
                        Departure = DateTime.Parse(parts[5].Trim(), null, DateTimeStyles.RoundtripKind),
                        Arrival = DateTime.Parse(parts[6].Trim(), null, DateTimeStyles.RoundtripKind)
                    });
                }
                catch
                {
                    // ignorar líneas mal formateadas
                }
            }
            return list;
        }

        static Dictionary<string, List<FlightEdge>> BuildGraph(List<Flight> flights)
        {
            var g = new Dictionary<string, List<FlightEdge>>(StringComparer.OrdinalIgnoreCase);
            foreach (var f in flights)
            {
                if (!g.ContainsKey(f.From)) g[f.From] = new List<FlightEdge>();
                g[f.From].Add(new FlightEdge { To = f.To, Weight = f.Price, FlightId = f.Id });
                // not adding reverse edge because flights are directed
            }
            return g;
        }

        class PathResult
        {
            public decimal TotalPrice { get; set; }
            public List<string> Path { get; set; } = new List<string>();
        }

        // Dijkstra but limiting number of stops: we encode (node, stops) state
        static PathResult FindCheapestPath(Dictionary<string, List<FlightEdge>> graph, string origin, string dest, int maxStops)
        {
            origin = origin?.Trim();
            dest = dest?.Trim();
            if (string.IsNullOrEmpty(origin) || string.IsNullOrEmpty(dest)) return null;
            if (origin.Equals(dest, StringComparison.OrdinalIgnoreCase))
                return new PathResult { TotalPrice = 0m, Path = new List<string>() };

            // priority queue using SortedSet for simplicity
            var comparer = Comparer<(decimal cost, string node, int stops, string viaFlight, string prevKey)>.Create((a, b) =>
            {
                int c = a.cost.CompareTo(b.cost);
                if (c != 0) return c;
                c = a.node.CompareTo(b.node);
                if (c != 0) return c;
                return a.stops.CompareTo(b.stops);
            });
            var pq = new SortedSet<(decimal cost, string node, int stops, string viaFlight, string prevKey)>(comparer);
            // dictionary for best cost for (node, stops) -> keep predecessor info
            var best = new Dictionary<string, decimal>(); // key: node|stops
            var parent = new Dictionary<string, (string prevKey, string flightId)>();

            string Key(string node, int stops) => $"{node}|{stops}";
            pq.Add((0m, origin, 0, null, Key(origin, 0)));
            best[Key(origin, 0)] = 0m;
            parent[Key(origin, 0)] = (null, null);

            while (pq.Any())
            {
                var cur = pq.Min;
                pq.Remove(cur);
                decimal cost = cur.cost;
                string node = cur.node;
                int stops = cur.stops;
                string curKey = Key(node, stops);

                if (string.Equals(node, dest, StringComparison.OrdinalIgnoreCase))
                {
                    // reconstruct path of flight IDs
                    var flightPath = new List<string>();
                    var k = cur.prevKey;
                    // current state's key is cur.prevKey (set when pushing)
                    // Actually we store parent keyed by Key(node, stops). We have cur.prevKey as Key(node,stops).
                    var kk = cur.prevKey;
                    while (kk != null && parent.ContainsKey(kk))
                    {
                        var p = parent[kk];
                        if (p.flightId != null) flightPath.Add(p.flightId);
                        kk = p.prevKey;
                    }
                    flightPath.Reverse();
                    return new PathResult { TotalPrice = cost, Path = flightPath };
                }

                if (!graph.ContainsKey(node)) continue;
                if (stops > maxStops) continue; // exceeded

                foreach (var edge in graph[node])
                {
                    string next = edge.To;
                    int nextStops = stops + 1;
                    if (nextStops > maxStops + 1) continue; // we allow maxStops connections => nodes visited <= maxStops+1?
                    decimal nCost = cost + edge.Weight;
                    var nKey = Key(next, nextStops);
                    if (!best.ContainsKey(nKey) || nCost < best[nKey])
                    {
                        best[nKey] = nCost;
                        parent[nKey] = (cur.prevKey, edge.FlightId);
                        pq.Add((nCost, next, nextStops, edge.FlightId, nKey));
                    }
                }
            }

            return null;
        }

        static void ListFlights(List<Flight> flights)
        {
            Console.WriteLine("--- Vuelos cargados ---");
            foreach (var f in flights.OrderBy(x => x.Id))
                Console.WriteLine(f);
        }

        static void AddFlightInteractive(List<Flight> flights, Dictionary<string, List<FlightEdge>> graph)
        {
            Console.WriteLine("Agregar nuevo vuelo (dejar ID en blanco para cancelar)");
            Console.Write("ID: ");
            var id = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(id)) return;
            Console.Write("Origen: "); var from = Console.ReadLine();
            Console.Write("Destino: "); var to = Console.ReadLine();
            Console.Write("Precio (numero): "); decimal price = 0; decimal.TryParse(Console.ReadLine(), out price);
            Console.Write("Duración (minutos): "); int dur = 0; int.TryParse(Console.ReadLine(), out dur);
            Console.Write("Salida (YYYY-MM-DDTHH:MM): "); DateTime dep = DateTime.Now; DateTime.TryParse(Console.ReadLine(), out dep);
            Console.Write("Llegada (YYYY-MM-DDTHH:MM): "); DateTime arr = DateTime.Now; DateTime.TryParse(Console.ReadLine(), out arr);

            var f = new Flight
            {
                Id = id.Trim(),
                From = from?.Trim(),
                To = to?.Trim(),
                Price = price,
                DurationMin = dur,
                Departure = dep,
                Arrival = arr
            };
            flights.Add(f);
            // update graph
            if (!graph.ContainsKey(f.From)) graph[f.From] = new List<FlightEdge>();
            graph[f.From].Add(new FlightEdge { To = f.To, Weight = f.Price, FlightId = f.Id });
            Console.WriteLine("Vuelo agregado.");
        }

        static void SaveFlights(string path, List<Flight> flights)
        {
            var lines = flights.Select(f =>
                $"{f.Id};{f.From};{f.To};{f.Price.ToString(CultureInfo.InvariantCulture)};{f.DurationMin};{f.Departure:yyyy-MM-ddTHH:mm};{f.Arrival:yyyy-MM-ddTHH:mm}"
            );
            File.WriteAllLines(path, lines);
        }

        static void ShowReport(Dictionary<string, List<FlightEdge>> graph, List<Flight> flights)
        {
            Console.WriteLine("=== Reporte de la estructura ===");
            Console.WriteLine($"Número de vuelos: {flights.Count}");
            var airports = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var f in flights) { airports.Add(f.From); airports.Add(f.To); }
            Console.WriteLine($"Aeropuertos (nodos): {airports.Count}");
            Console.WriteLine();
            Console.WriteLine("Grado saliente por aeropuerto:");
            foreach (var a in airports.OrderBy(x => x))
            {
                int outdeg = graph.ContainsKey(a) ? graph[a].Count : 0;
                Console.WriteLine($" - {a}: salientes = {outdeg}");
            }
            Console.WriteLine();
            Console.WriteLine("Top 5 vuelos más baratos:");
            foreach (var f in flights.OrderBy(x => x.Price).Take(5))
                Console.WriteLine($"  {f.Id}: {f.From}->{f.To} ${f.Price}");
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Pulse ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

