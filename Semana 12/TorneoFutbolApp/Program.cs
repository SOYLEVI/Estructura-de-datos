// Proyecto: TorneoFutbolApp
// Uso: Consola para registrar jugadores y equipos usando HashSet y Dictionary
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TorneoFutbolApp
{
    // Clase Player: representamos la identidad del jugador. Implementa IEquatable para HashSet.
    public class Player : IEquatable<Player>
    {
        public int Id { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public Player(int id, string name, int age, string position)
        {
            Id = id;
            Name = string.IsNullOrWhiteSpace(name) ? "SinNombre" : name.Trim();
            Age = age;
            Position = position ?? "";
        }

        // Igualdad basada en Id (clave única)
        public bool Equals(Player other)
        {
            if (other is null) return false;
            return Id == other.Id;
        }

        public override bool Equals(object obj) => Equals(obj as Player);

        // Importante para HashSet: GetHashCode consistente con Equals
        public override int GetHashCode() => Id.GetHashCode();

        public override string ToString() => $"[{Id}] {Name} ({Age}) - {Position}";
    }

    // Clase Team: contiene un HashSet de jugadores asignados (por objeto Player)
    public class Team
    {
        public string Name { get; }
        private HashSet<Player> players = new HashSet<Player>();

        public Team(string name)
        {
            Name = name?.Trim() ?? "EquipoSinNombre";
        }

        public bool AddPlayer(Player p) => players.Add(p); // true si agregado (no duplicado)
        public bool RemovePlayer(Player p) => players.Remove(p);
        public IEnumerable<Player> Players => players;

        public override string ToString()
        {
            return $"{Name} (Jugadores: {players.Count})";
        }
    }

    // Manager: coordina los conjuntos y mapas
    public class TournamentManager
    {
        // Conjunto global de jugadores (no duplicados)
        private HashSet<Player> allPlayers = new HashSet<Player>();
        // Mapa de equipos por nombre
        private Dictionary<string, Team> teams = new Dictionary<string, Team>(StringComparer.OrdinalIgnoreCase);

        // Añadir jugador (si mismo Id ya existe no se agrega)
        public bool AddPlayer(Player p) => allPlayers.Add(p);

        public bool RemovePlayerById(int id)
        {
            var player = allPlayers.FirstOrDefault(x => x.Id == id);
            if (player == null) return false;
            // Remover de equipos si pertenece
            foreach (var team in teams.Values) team.RemovePlayer(player);
            return allPlayers.Remove(player);
        }

        public Player GetPlayerById(int id) => allPlayers.FirstOrDefault(x => x.Id == id);

        public IEnumerable<Player> SearchPlayersByName(string term)
        {
            if (string.IsNullOrWhiteSpace(term)) return Enumerable.Empty<Player>();
            term = term.Trim().ToLower();
            return allPlayers.Where(p => p.Name.ToLower().Contains(term));
        }

        public bool AddTeam(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName)) return false;
            if (teams.ContainsKey(teamName)) return false;
            teams[teamName] = new Team(teamName);
            return true;
        }

        public bool RemoveTeam(string teamName) => teams.Remove(teamName);

        public bool AssignPlayerToTeam(int playerId, string teamName)
        {
            var player = GetPlayerById(playerId);
            if (player == null) return false;
            if (!teams.TryGetValue(teamName, out var team)) return false;
            return team.AddPlayer(player);
        }

        public IEnumerable<Team> ListTeams() => teams.Values;

        public IEnumerable<Player> ListAllPlayers() => allPlayers;

        public IEnumerable<Player> GetPlayersOfTeam(string teamName)
        {
            if (!teams.TryGetValue(teamName, out var team)) return Enumerable.Empty<Player>();
            return team.Players;
        }

        // Función para pruebas de rendimiento: agrega N jugadores con IDs secuenciales
        public (TimeSpan insertTime, TimeSpan lookupTime) RunPerformanceTest(int n)
        {
            // Clean
            allPlayers.Clear();
            teams.Clear();

            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                AddPlayer(new Player(i + 1, $"Jugador{i + 1}", 18 + (i % 15), "MC"));
            }
            sw.Stop();
            var insertTime = sw.Elapsed;

            // Medir búsquedas aleatorias
            var rand = new Random(0);
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < 10000; i++)
            {
                int id = rand.Next(1, n + 1);
                var p = GetPlayerById(id);
            }
            sw2.Stop();
            var lookupTime = sw2.Elapsed;

            return (insertTime, lookupTime);
        }
    }

    class Program
    {
        static TournamentManager manager = new TournamentManager();

        static void Main(string[] args)
        {
            SeedSampleData();

            while (true)
            {
                PrintMenu();
                Console.Write("Opción: ");
                var opt = Console.ReadLine();
                if (string.IsNullOrEmpty(opt)) continue;
                switch (opt.Trim())
                {
                    case "1": AddPlayerInteractive(); break;
                    case "2": AddTeamInteractive(); break;
                    case "3": AssignPlayerInteractive(); break;
                    case "4": ListPlayers(); break;
                    case "5": ListTeams(); break;
                    case "6": ListPlayersOfTeam(); break;
                    case "7": SearchPlayerByName(); break;
                    case "8": RemovePlayer(); break;
                    case "9": PerformanceTest(); break;
                    case "0": Console.WriteLine("Saliendo..."); return;
                    default: Console.WriteLine("Opción no válida."); break;
                }
                Console.WriteLine("\nPresiona ENTER para continuar...");
                Console.ReadLine();
            }
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("=== TORNEO FUTBOL - GESTIÓN (Conjuntos y Mapas) ===");
            Console.WriteLine("1) Registrar jugador");
            Console.WriteLine("2) Registrar equipo");
            Console.WriteLine("3) Asignar jugador a equipo");
            Console.WriteLine("4) Listar todos los jugadores");
            Console.WriteLine("5) Listar equipos");
            Console.WriteLine("6) Listar jugadores por equipo");
            Console.WriteLine("7) Buscar jugador por nombre");
            Console.WriteLine("8) Eliminar jugador por ID");
            Console.WriteLine("9) Prueba rendimiento (Insert + Lookup)");
            Console.WriteLine("0) Salir");
            Console.WriteLine("==================================================");
        }

        static void SeedSampleData()
        {
            // Datos de muestra
            manager.AddPlayer(new Player(1, "Carlos Perez", 23, "Delantero"));
            manager.AddPlayer(new Player(2, "Luis Gomez", 21, "Mediocentro"));
            manager.AddPlayer(new Player(3, "Andres Solis", 26, "Defensa"));
            manager.AddTeam("Tigres");
            manager.AddTeam("Leones");
            manager.AssignPlayerToTeam(1, "Tigres");
            manager.AssignPlayerToTeam(2, "Leones");
        }

        static void AddPlayerInteractive()
        {
            Console.Write("ID (numero entero): ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido.");
                return;
            }
            Console.Write("Nombre: ");
            var name = Console.ReadLine();
            Console.Write("Edad: ");
            if (!int.TryParse(Console.ReadLine(), out int age)) age = 18;
            Console.Write("Posición: ");
            var pos = Console.ReadLine();
            var p = new Player(id, name, age, pos);
            if (manager.AddPlayer(p)) Console.WriteLine("Jugador agregado.");
            else Console.WriteLine("No se pudo agregar. ID duplicado.");
        }

        static void AddTeamInteractive()
        {
            Console.Write("Nombre equipo: ");
            var name = Console.ReadLine();
            if (manager.AddTeam(name)) Console.WriteLine("Equipo agregado.");
            else Console.WriteLine("No se pudo agregar (nombre duplicado).");
        }

        static void AssignPlayerInteractive()
        {
            Console.Write("ID jugador: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            Console.Write("Equipo destino: ");
            var team = Console.ReadLine();
            if (manager.AssignPlayerToTeam(id, team)) Console.WriteLine("Jugador asignado al equipo.");
            else Console.WriteLine("Asignación fallida (verificar ID y equipo).");
        }

        static void ListPlayers()
        {
            Console.WriteLine("=== Jugadores registrados ===");
            foreach (var p in manager.ListAllPlayers().OrderBy(x => x.Id)) Console.WriteLine(p);
        }

        static void ListTeams()
        {
            Console.WriteLine("=== Equipos ===");
            foreach (var t in manager.ListTeams()) Console.WriteLine(t);
        }

        static void ListPlayersOfTeam()
        {
            Console.Write("Nombre equipo: ");
            var name = Console.ReadLine();
            var list = manager.GetPlayersOfTeam(name);
            Console.WriteLine($"Jugadores en {name}:");
            foreach (var p in list) Console.WriteLine(p);
        }

        static void SearchPlayerByName()
        {
            Console.Write("Término búsqueda (nombre): ");
            var term = Console.ReadLine();
            var results = manager.SearchPlayersByName(term);
            Console.WriteLine($"Resultados para '{term}':");
            foreach (var p in results) Console.WriteLine(p);
        }

        static void RemovePlayer()
        {
            Console.Write("ID jugador a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id)) { Console.WriteLine("ID inválido."); return; }
            if (manager.RemovePlayerById(id)) Console.WriteLine("Jugador eliminado.");
            else Console.WriteLine("No existe jugador con ese ID.");
        }

        static void PerformanceTest()
        {
            Console.Write("Cantidad N de jugadores a insertar (ej: 100000): ");
            if (!int.TryParse(Console.ReadLine(), out int n)) n = 100000;
            Console.WriteLine("Ejecutando prueba... (esto puede tardar)");
            var (insertTime, lookupTime) = manager.RunPerformanceTest(n);
            Console.WriteLine($"Tiempo inserción {n} jugadores: {insertTime.TotalMilliseconds} ms");
            Console.WriteLine($"Tiempo 10000 búsquedas aleatorias: {lookupTime.TotalMilliseconds} ms");
        }
    }
}

