using System;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        string expression1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expression2 = "{[()]}}";
        string expression3 = "(()";
        string expression4 = "{[()]";

        Console.WriteLine($"Expresión: {expression1}");
        if (BalanceChecker(expression1))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.\n");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.\n");
        }

        Console.WriteLine($"Expresión: {expression2}");
        if (BalanceChecker(expression2))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.\n");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.\n");
        }

        Console.WriteLine($"Expresión: {expression3}");
        if (BalanceChecker(expression3))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.\n");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.\n");
        }

        Console.WriteLine($"Expresión: {expression4}");
        if (BalanceChecker(expression4))
        {
            Console.WriteLine("Resultado: Fórmula balanceada.\n");
        }
        else
        {
            Console.WriteLine("Resultado: Fórmula NO balanceada.\n");
        }
    }

    private static bool BalanceChecker(string expression1)
    {
        throw new NotImplementedException();
    }
}


    