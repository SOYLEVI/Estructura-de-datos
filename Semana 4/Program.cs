// --- Clase principal donde se ejecuta el programa ---
class Program
{
    static void Main(string[] args)
    {
        // Creamos una instancia de nuestra Agenda. Este es el "corazón" de nuestra aplicación.
        Agenda miAgenda = new Agenda();

        // Bucle principal del menú
        while (true)
        {
            Console.WriteLine("\n--- Menú de Agenda de Servicios ---");
            Console.WriteLine("1. Agregar nuevo Servicio");
            Console.WriteLine("2. Mostrar todos los servicios");
            Console.WriteLine("3. Salir");
            Console.Write("Selecciona una opción: ");

            // Leemos la opción del usuario
            string opcion = Console.ReadLine();

            // Usamos una estructura switch para manejar las diferentes opciones
            switch (opcion)
            {
                case "1":
                    Console.Write("Nombre del servicio: ");
                    string nombre = Console.ReadLine(); // Resultado: cadena de texto

                    Console.Write("Descripción del servicio: ");
                    string descripcion = Console.ReadLine(); // Resultado: cadena de texto

                    // Usamos el procedimiento ObtenerFechaValida para obtener un DateTime
                    DateTime fechaHora = miAgenda.ObtenerFechaValida("Fecha y Hora del servicio (dd/MM/yyyy HH:mm): ");

                    // Llamamos al procedimiento AgregarServicio de nuestra Agenda
                    miAgenda.AgregarServicio(nombre, fechaHora, descripcion);
                    break;
                case "2":
                    // Llamamos al procedimiento MostrarServicios de nuestra Agenda
                    miAgenda.MostrarServicios(); // El resultado es la impresión de los servicios
                    break;
                case "3":
                    Console.WriteLine("Saliendo de la agenda. ¡Hasta pronto!");
                    return; // Terminamos el programa
                default:
                    Console.WriteLine("Opción inválida. Por favor, intenta de nuevo.");
                    break;
            }
        }
    }
}
