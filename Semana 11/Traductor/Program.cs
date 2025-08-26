using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Diccionario inicial (Español -> Inglés)
        Dictionary<string, string> diccionario = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            {"tiempo", "time"},
            {"persona", "person"},
            {"año", "year"},
            {"camino", "way"},
            {"forma", "way"},
            {"día", "day"},
            {"cosa", "thing"},
            {"hombre", "man"},
            {"mundo", "world"},
            {"vida", "life"},
            {"mano", "hand"},
            {"parte", "part"},
            {"niño", "child"},
            {"niña", "child"},
            {"ojo", "eye"},
            {"mujer", "woman"},
            {"lugar", "place"},
            {"trabajo", "work"},
            {"semana", "week"},
            {"caso", "case"},
            {"punto", "point"},
            {"tema", "point"},
            {"gobierno", "government"},
            {"empresa", "company"},
            {"compañía", "company"}
        };

        int opcion;
        do
        {
            Console.WriteLine("\n==================== MENÚ ====================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("⚠️ Opción inválida.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase(diccionario);
                    break;
                case 2:
                    AgregarPalabra(diccionario);
                    break;
                case 0:
                    Console.WriteLine("👋 Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("⚠️ Opción inválida.");
                    break;
            }

        } while (opcion != 0);
    }

    static void TraducirFrase(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese una frase en español: ");
        string frase = Console.ReadLine() ?? "";
        string[] palabras = frase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < palabras.Length; i++)
        {
            string palabraLimpia = palabras[i].Trim(',', '.', ';', '!', '?').ToLower();
            if (diccionario.TryGetValue(palabraLimpia, out string? traduccion))
            {
                palabras[i] = palabras[i].Replace(palabraLimpia, traduccion, StringComparison.OrdinalIgnoreCase);
            }
        }

        Console.WriteLine("\nTraducción: " + string.Join(" ", palabras));
    }

    static void AgregarPalabra(Dictionary<string, string> diccionario)
    {
        Console.Write("\nIngrese la palabra en español: ");
        string esp = Console.ReadLine()?.Trim().ToLower() ?? "";

        Console.Write("Ingrese la traducción en inglés: ");
        string eng = Console.ReadLine()?.Trim().ToLower() ?? "";

        if (!string.IsNullOrEmpty(esp) && !string.IsNullOrEmpty(eng))
        {
            diccionario[esp] = eng;
            Console.WriteLine($"✅ Palabra agregada: {esp} -> {eng}");
        }
        else
        {
            Console.WriteLine("⚠️ No se pudo agregar la palabra.");
        }
    }
}

