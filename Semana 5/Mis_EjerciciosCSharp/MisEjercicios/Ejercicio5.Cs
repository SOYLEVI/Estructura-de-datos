using System;
using System.Collections.Generic;
using System.Linq;

public class NumberReverser
{
    private List<int> numbers;

    public NumberReverser()
    {
        numbers = new List<int>();
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }
    }

    public void DisplayNumbersInReverse()
    {
        // Invierte la lista y la convierte en una cadena separada por comas
        string reversedNumbers = string.Join(", ", numbers.AsEnumerable().Reverse());
        Console.WriteLine($"Números en orden inverso: {reversedNumbers}");
    }
}

public class Exercise5
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 5: Números en orden inverso ---");
        NumberReverser reverser = new NumberReverser();
        reverser.DisplayNumbersInReverse();
        Console.WriteLine();
    }
}