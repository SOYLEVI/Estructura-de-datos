using System;
using System.Collections.Generic;
using System.Linq; // Para usar Reverse() en la impresión

public class TowersOfHanoi
{
    // Pilas para representar las torres
    private static Stack<int> towerA = new Stack<int>(); // Origen
    private static Stack<int> towerB = new Stack<int>(); // Auxiliar
    private static Stack<int> towerC = new Stack<int>(); // Destino

    private static int numMoves = 0; // Contador de movimientos

    public static void Main(string[] args)
    {
        Console.Write("Ingrese el número de discos para las Torres de Hanoi: ");
        if (int.TryParse(Console.ReadLine(), out int numDisks) && numDisks > 0)
        {
            InitializeTowers(numDisks);
            Console.WriteLine("\nEstado inicial de las torres:");
            PrintTowers();

            Console.WriteLine("\nComenzando la resolución de las Torres de Hanoi...\n");
            SolveHanoi(numDisks, towerA, towerC, towerB);

            Console.WriteLine($"\n¡Problema resuelto en {numMoves} movimientos!");
            Console.WriteLine("Estado final de las torres:");
            PrintTowers();
        }
        else
        {
            Console.WriteLine("Número de discos inválido. Por favor, ingrese un número entero positivo.");
        }
    }

    // Inicializa la torre de origen con los discos
    private static void InitializeTowers(int numDisks)
    {
        for (int i = numDisks; i >= 1; i--)
        {
            towerA.Push(i);
        }
    }

    // Resuelve el problema de las Torres de Hanoi recursivamente
    private static void SolveHanoi(int n, Stack<int> source, Stack<int> destination, Stack<int> auxiliary)
    {
        if (n > 0)
        {
            // Mover n-1 discos de origen a auxiliar, usando destino como auxiliar
            SolveHanoi(n - 1, source, auxiliary, destination);

            // Mover el disco actual de origen a destino
            MoveDisk(source, destination);
            numMoves++;
            Console.WriteLine($"Movimiento #{numMoves}: Mover disco {destination.Peek()} de {GetName(source)} a {GetName(destination)}");
            PrintTowers();

            // Mover n-1 discos de auxiliar a destino, usando origen como auxiliar
            SolveHanoi(n - 1, auxiliary, destination, source);
        }
    }

    // Realiza el movimiento de un disco de una torre a otra
    private static void MoveDisk(Stack<int> source, Stack<int> destination)
    {
        if (source.Count == 0)
        {
            throw new InvalidOperationException("La torre de origen está vacía.");
        }
        if (destination.Count > 0 && destination.Peek() < source.Peek())
        {
            throw new InvalidOperationException("No se puede colocar un disco grande sobre uno más pequeño.");
        }

        int disk = source.Pop();
        destination.Push(disk);
    }
