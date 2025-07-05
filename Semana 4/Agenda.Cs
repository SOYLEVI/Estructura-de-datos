// --- 2. Clase Agenda: Gestiona la colección de Servicios ---
public class Agenda
{
    // Una lista para almacenar nuestros objetos Servicio. Este es nuestro "almacén" de datos.
    private List<Servicio> _servicios;

    // Constructor de la Agenda: Inicializa la lista cuando creamos una Agenda
    public Agenda()
    {
        _servicios = new List<Servicio>();
    }

    // Procedimiento (Método): Agrega un nuevo servicio a la lista
    public void AgregarServicio(string nombre, DateTime fechaHora, string descripcion)
    {
        // Creamos una nueva instancia de Servicio usando el constructor
        Servicio nuevoServicio = new Servicio(nombre, fechaHora, descripcion);
        _servicios.Add(nuevoServicio); // Agregamos el nuevo servicio a nuestra lista
        Console.WriteLine("\n¡Servicio agregado con éxito!"); // Resultado: mensaje de confirmación
    }

    // Procedimiento (Método): Muestra todos los servicios agendados
    public void MostrarServicios()
    {
        Console.WriteLine("\n--- Tus Servicios Agendados ---");
        // Resultado: Si la lista está vacía, mostramos un mensaje.
        if (!_servicios.Any()) // .Any() verifica si hay elementos en la lista
        {
            Console.WriteLine("No hay servicios agendados aún.");
        }
        else
        {
            // Iteramos sobre cada servicio en nuestra lista
            foreach (var servicio in _servicios.OrderBy(s => s.FechaHora)) // Ordenamos por fecha y hora
            {
                // Para cada servicio, llamamos a su método ToString() para obtener la representación de texto
                // El resultado es la impresión en consola de cada servicio
                Console.WriteLine(servicio.ToString());
            }
        }
        Console.WriteLine("------------------------------");
    }

    // Procedimiento (Método auxiliar): Pide y valida una fecha y hora al usuario
    public DateTime ObtenerFechaValida(string mensaje)
    {
        DateTime fecha;
        while (true) // Bucle para seguir pidiendo hasta que la entrada sea válida
        {
            Console.Write(mensaje);
            // Intenta convertir la entrada del usuario a un DateTime
            // El resultado de TryParse es un booleano (true/false) y la fecha parseada
            if (DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                // Validar que la fecha no sea en el pasado. (Considerando la hora local actual de Ecuador)
                if (fecha < DateTime.Now)
                {
                    Console.WriteLine("La fecha y hora no pueden ser en el pasado. Intenta de nuevo.");
                }
                else
                {
                    return fecha; // Si es válida, retorna el valor DateTime
                }
            }
            else
            {
                // Resultado: mensaje de error si el formato es incorrecto
                Console.WriteLine("Formato de fecha y hora inválido. Usa dd/MM/yyyy HH:mm (ej. 25/12/2025 14:30)");
            }
        }
    }
}