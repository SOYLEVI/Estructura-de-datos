using System;
using System.Collections.Generic;

public class Atraccion
{
    private Queue<Persona> cola = new Queue<Persona>();
    private int capacidadMaxima = 30;

    public void IngresarPersona(Persona persona)
    {
        if (cola.Count < capacidadMaxima)
        {
            cola.Enqueue(persona);
            Console.WriteLine($"{persona.Nombre} ha ingresado a la fila.");
        }
        else
        {
            Console.WriteLine($"¡La atracción está llena! {persona.Nombre} no puede ingresar.");
        }
    }

    public void IniciarAtraccion()
    {
        Console.WriteLine("\n--- Iniciando atracción ---");
        int asiento = 1;
        while (cola.Count > 0)
        {
            Persona p = cola.Dequeue();
            Console.WriteLine($"Asiento {asiento++}: {p.Nombre}");
        }
        Console.WriteLine("--- Atracción finalizada ---");
    }

    public void VerCola()
    {
        Console.WriteLine("\nPersonas en la cola:");
        foreach (var persona in cola)
        {
            Console.WriteLine($"- {persona.Nombre}");
        }
    }

    public int PersonasEnCola()
    {
        return cola.Count;
    }
}
