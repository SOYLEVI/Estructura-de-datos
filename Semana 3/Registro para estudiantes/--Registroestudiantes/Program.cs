using System; // Importa el espacio de nombres System para funcionalidades básicas como Console

public class Program
{
    public static void Main(string[] args)
    {
        // Creación de una instancia de la clase Estudiante
        // Se crea un nuevo objeto Estudiante y se inicializan sus propiedades
        // Se pasan tres números de teléfono directamente al constructor.
        Estudiante estudiante1 = new Estudiante(
            1001,
            "Juan",
            "Pérez García",
            "Av. Siempre Viva 123",
            "0987654321", "022567890", "0991234567"
        );

        // Llamada al método para mostrar la información del estudiante
        Console.WriteLine("Información del Estudiante 1:");
        estudiante1.MostrarInformacion();

        // Creación de otra instancia de Estudiante con diferentes datos
        Estudiante estudiante2 = new Estudiante(
            1002,
            "María",
            "López Sánchez",
            "Calle Falsa 456",
            "0965432109", "022112233" // Este estudiante solo tiene dos teléfonos
        );

        Console.WriteLine("\nInformación del Estudiante 2:");
        estudiante2.MostrarInformacion();

        // Ejemplo de cómo acceder y modificar elementos del array de teléfonos directamente
        Console.WriteLine("\nModificando el segundo teléfono del Estudiante 1:");
        estudiante1.Telefonos[1] = "022987654"; // Modifica el segundo teléfono (índice 1)
        estudiante1.MostrarInformacion();

        Console.ReadKey(); // Pausa la consola hasta que se presione una tecla
    }
}