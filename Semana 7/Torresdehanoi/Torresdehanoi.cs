using System;
using System.Collections.Generic;

/// <summary>
/// Resuelve el problema de las Torres de Hanoi utilizando recursión y muestra los pasos.
/// </summary>
public static class HanoiSolver
{
    /// <summary>
    /// Mueve n discos desde la torre origen a la torre destino usando la torre auxiliar.
    /// </summary>
    public static void SolveHanoi(int n, char origen, char auxiliar, char destino)
    {
        if (n == 1)
        {
            Console.WriteLine($"Mover disco 1 de {origen} a {destino}");
            return;
        }

        SolveHanoi(n - 1, origen, destino, auxiliar);
        Console.WriteLine($"Mover disco {n} de {origen} a {destino}");
        SolveHanoi(n - 1, auxiliar, origen, destino);
    }
}
