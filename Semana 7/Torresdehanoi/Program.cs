using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Resolución del Problema de las Torres de Hanoi ---");

        Console.Write("Introduce el número de discos (ej: 3): ");
        if (int.TryParse(Console.ReadLine(), out int numberOfDisks) && numberOfDisks > 0)
        {
            Console.WriteLine($"\nMoviendo {numberOfDisks} discos de la Torre A a la Torre C (Torre B es auxiliar):");
            HanoiSolver.SolveHanoi(numberOfDisks, 'A', 'B', 'C');
        }
        else
        {
            Console.WriteLine("Entrada inválida. Por favor, introduce un número entero positivo.");
        }

        Console.WriteLine("\nPrograma de Torres de Hanoi finalizado.");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }
}
