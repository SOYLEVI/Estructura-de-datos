using System;
using System.Collections.Generic;
using System.Linq;

public class VocalCounter
{
    private string word;
    private Dictionary<char, int> vocalCounts;

    // Constructor que recibe la palabra y la procesa
    public VocalCounter(string inputWord)
    {
        // Convertimos la palabra a minúsculas para un conteo no sensible a mayúsculas/minúsculas
        word = inputWord.ToLower();
        vocalCounts = new Dictionary<char, int>
        {
            {'a', 0},
            {'e', 0},
            {'i', 0},
            {'o', 0},
            {'u', 0}
        };
        CountVocals();
    }

    // Método privado para contar las vocales
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

    // Método público para mostrar los resultados
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

        // Creamos una instancia de VocalCounter, pasando la palabra ingresada
        VocalCounter counter = new VocalCounter(inputWord);
        
        // Llamamos al método para mostrar los resultados
        counter.DisplayVocalCounts();
        Console.WriteLine();
    }
}