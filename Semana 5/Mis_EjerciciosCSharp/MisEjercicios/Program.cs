// Program.cs
using System;
using System.Collections.Generic;
using System.Linq; //

// Clases de Ejercicio 5
public class NumberReverser { /* ...código... */ }
public class Exercise5 { /* ...código... */ }

// Clases de Ejercicio 6
public class Course { /* ...código... */ }
public class CourseManager { /* ...código... */ }
public class Exercise6 { /* ...código... */ }

// Clases de Ejercicio 7
public class AlphabetFilter { /* ...código... */ }
public class Exercise7 { /* ...código... */ }

// Clases de Ejercicio 8
public class PalindromeChecker { /* ...código... */ }
public class Exercise8 { /* ...código... */ }

//--- Clases de Ejercicio 9 ---
public class VocalCounter
{
    private string word;
    private Dictionary<char, int> vocalCounts;

    public VocalCounter(string inputWord)
    {
        word = inputWord.ToLower();
        vocalCounts = new Dictionary<char, int>
        {
            {'a', 0}, {'e', 0}, {'i', 0}, {'o', 0}, {'u', 0}
        };
        CountVocals();
    }

    private void CountVocals()
    {
        foreach (char character in word)
        {
            if (vocalCounts.ContainsKey(character))
            {
                vocalCounts[character]++;
            }
        }
    }

    public void DisplayVocalCounts()
    {
        Console.WriteLine($"\nConteo de vocales para la palabra '{word}':");
        foreach (var entry in vocalCounts)
        {
            Console.WriteLine($"- La vocal '{entry.Key}' aparece {entry.Value} vez(es).");
        }
    }
}

public class Exercise9
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 9: Conteo de Vocales ---");
        Console.Write("Por favor, ingrese una palabra: ");
        string inputWord = Console.ReadLine();
        
        VocalCounter counter = new VocalCounter(inputWord);
        counter.DisplayVocalCounts();
        Console.WriteLine();
    }
}
//--- Fin Clases de Ejercicio 9 ---

// Clases de Ejercicio 10
public class PriceAnalyzer { /* ...código... */ }
public class Exercise10 { /* ...código... */ }

public class Program
{
    public static void Main(string[] args)
    {
        Exercise5.Run();
        Exercise6.Run();
        Exercise7.Run();
        Exercise8.Run();
        Exercise9.Run(); // Esta línea ya la tienes, asegura que sea la última para el Ej. 9 
        Exercise10.Run();

        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
