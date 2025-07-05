using System;
using System.Collections.Generic;
using System.Linq;

public class PriceAnalyzer
{
    private List<double> prices;

    public PriceAnalyzer()
    {
        prices = new List<double> { 50, 75, 46, 22, 80, 65, 8 };
    }

    public double GetMinPrice()
    {
        return prices.Min();
    }

    public double GetMaxPrice()
    {
        return prices.Max();
    }

    public void DisplayMinMaxPrices()
    {
        Console.WriteLine($"Precios: {string.Join(", ", prices)}");
        Console.WriteLine($"El precio menor es: {GetMinPrice()}");
        Console.WriteLine($"El precio mayor es: {GetMaxPrice()}");
    }
}

public class Exercise10
{
    public static void Run()
    {
        Console.WriteLine("--- Ejercicio 10: Precios - Menor y Mayor ---");
        PriceAnalyzer analyzer = new PriceAnalyzer();
        analyzer.DisplayMinMaxPrices();
        Console.WriteLine();
    }
}