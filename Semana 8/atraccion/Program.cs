using System;

class Program
{
    static void Main()
    {
        Atraccion atraccion = new Atraccion();

        // Simular ingreso de personas
        for (int i = 1; i <= 32; i++) // Intencionalmente 32 para probar el límite
        {
            atraccion.IngresarPersona(new Persona("Persona " + i));
        }

        // Consultar estado de la cola
        atraccion.VerCola();
        Console.WriteLine($"\nTotal de personas en cola: {atraccion.PersonasEnCola()}");

        // Iniciar la atracción
        atraccion.IniciarAtraccion();
    }
}
