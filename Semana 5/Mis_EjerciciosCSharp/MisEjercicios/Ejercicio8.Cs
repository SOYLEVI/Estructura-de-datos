using System;
using System.Linq;

public class PalindromeChecker
{
    private string word;

    public PalindromeChecker(string inputWord)
    {
        // Convierte la palabra a minúsculas y elimina espacios para una verificación más robusta
        word = inputWord.ToLower().Replace(" ", "");
    }

    public bool IsPalindrome()
    {
        string reversedWord = new string(word.Reverse().ToArray());
        return word.Equals(reversedWord);
    }

    public void DisplayResult()
    {
        if (IsPalindrome())
        {
            Console.WriteLine($"'{word}' es un palíndromo.");
        }
        else
        {
            Console.WriteLine($"'{word}' no es un palíndromo.");
        }
    }
}

public class Exercise8
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 8: Palíndromo ---");
        Console.Write("Por favor, ingrese una palabra: ");
        string input = Console.ReadLine();
        
        PalindromeChecker checker = new PalindromeChecker(input);
        checker.DisplayResult();
        Console.WriteLine();
    }
}