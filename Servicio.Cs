// --- 1. Clase Servicio: Nuestro Tipo de Dato Personalizado ---
public class Servicio
{
    // Propiedades: Son como variables que pertenecen a cada objeto Servicio
    public string Nombre { get; set; }
    public DateTime FechaHora { get; set; }
    public string Descripcion { get; set; }

    // Constructor: Este es un procedimiento especial que se llama cuando creamos un nuevo Servicio
    public Servicio(string nombre, DateTime fechaHora, string descripcion)
    {
        Nombre = nombre;
        FechaHora = fechaHora;
        Descripcion = descripcion;
    }

    // Método ToString(): Un procedimiento que nos da una representación de texto del objeto
    public override string ToString()
    {
        // El resultado es una cadena de texto formateada
        return $"Servicio: {Nombre} | Fecha y Hora: {FechaHora:dd/MM/yyyy HH:mm} | Descripción: {Descripcion}";
    }
}