using System; // Importa el espacio de nombres System para funcionalidades básicas como Console//

public class Estudiante
{
    // Propiedades de la clase Estudiante//
    public int Id { get; set; } // Identificador único del estudiante//
    public string Nombres { get; set; } // Nombres del estudiante//
    public string Apellidos { get; set; } // Apellidos del estudiante//
    public string Direccion { get; set; } // Dirección de residencia del estudiante//

    // Array para almacenar los números de teléfono//
    // 'string[]' declara un array de cadenas de texto.//
    // 'Telefonos' es el nombre del array.//
    public string[] Telefonos { get; set; }

    // Constructor de la clase Estudiante//
    public Estudiante(int id, string nombres, string apellidos, string direccion, params string[] telefonos)
    {
        Id = id; // Asigna el valor del parámetro 'id' a la propiedad 'Id'//
        Nombres = nombres; // Asigna el valor del parámetro 'nombres' a la propiedad 'Nombres'//
        Apellidos = apellidos; // Asigna el valor del parámetro 'apellidos' a la propiedad 'Apellidos'//
        Direccion = direccion; // Asigna el valor del parámetro 'direccion' a la propiedad 'Direccion'//
        Telefonos = telefonos; // Asigna el array de teléfonos pasado como parámetro//
    }

    // Método para mostrar la información del estudiante
    // Este método es útil para imprimir los detalles de un estudiante en la consola.
    public void MostrarInformacion()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Nombres: {Nombres}");
        Console.WriteLine($"Apellidos: {Apellidos}");
        Console.WriteLine($"Dirección: {Direccion}");
        Console.Write("Teléfonos: ");
        // Itera sobre el array de teléfonos para imprimirlos, separados por comas.//
        for (int i = 0; i < Telefonos.Length; i++)
        {
            Console.Write(Telefonos[i]);
            if (i < Telefonos.Length - 1) // Agrega una coma si no es el último teléfono
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("\n--------------------"); // Separador para mejor lectura
    }
}