using System;
using System.Collections.Generic;
using System.Linq;

public class AlphabetFilter
{
    private List<char> alphabet;

    public AlphabetFilter()
    {
        alphabet = new List<char>();
        for (char c = 'a'; c <= 'z'; c++)
        {
            alphabet.Add(c);
        }
    }

    public void FilterAndDisplayAlphabet()
    {
        // Filtra las letras cuyas posiciones (índice + 1) no son múltiplos de 3
        // Se crea una nueva lista para evitar modificar la colección mientras se itera sobre ella.
        List<char> filteredAlphabet = new List<char>();
        for (int i = 0; i < alphabet.Count; i++)
        {
            if ((i + 1) % 3 != 0) // Posiciones múltiplos de 3 (1-basado)
            {
                filteredAlphabet.Add(alphabet[i]);
            }
        }
        
        Console.WriteLine($"Abecedario original: {string.Join("", alphabet)}");
        Console.WriteLine($"Abecedario filtrado (sin múltiplos de 3): {string.Join("", filteredAlphabet)}");
    }
}

public class Exercise7
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 7: Abecedario filtrado ---");
        AlphabetFilter filter = new AlphabetFilter();
        filter.FilterAndDisplayAlphabet();
        Console.WriteLine();
    }
}