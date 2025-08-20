using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class ProgramaVacunacion
{
    static void Main(string[] args)
    {
        // 1. Crear conjunto de 500 ciudadanos
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= 500; i++)
            ciudadanos.Add($"Ciudadano {i}");

        // 2. Crear conjunto ficticio de 75 ciudadanos vacunados con Pfizer
        HashSet<string> pfizer = new HashSet<string>(ciudadanos.Take(75));

        // 3. Crear conjunto ficticio de 75 ciudadanos vacunados con AstraZeneca
        HashSet<string> astrazeneca = new HashSet<string>(ciudadanos.Skip(50).Take(75));

        // 4. Operaciones de teoría de conjuntos
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos.Except(pfizer.Union(astrazeneca)));
        HashSet<string> ambasDosis = new HashSet<string>(pfizer.Intersect(astrazeneca));
        HashSet<string> soloPfizer = new HashSet<string>(pfizer.Except(astrazeneca));
        HashSet<string> soloAstraZeneca = new HashSet<string>(astrazeneca.Except(pfizer));

        // 5. Mostrar resultados en consola
        Console.WriteLine("📌 Ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("📌 Ciudadanos con ambas dosis: " + ambasDosis.Count);
        Console.WriteLine("📌 Ciudadanos solo Pfizer: " + soloPfizer.Count);
        Console.WriteLine("📌 Ciudadanos solo AstraZeneca: " + soloAstraZeneca.Count);

        // 6. Guardar resultados en TXT
        File.WriteAllLines("NoVacunados.txt", noVacunados);
        File.WriteAllLines("AmbasDosis.txt", ambasDosis);
        File.WriteAllLines("SoloPfizer.txt", soloPfizer);
        File.WriteAllLines("SoloAstraZeneca.txt", soloAstraZeneca);

        Console.WriteLine("\n✅ Resultados exportados en archivos TXT en la carpeta del proyecto.");
    }
}

