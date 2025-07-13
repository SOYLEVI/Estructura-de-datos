// Nodo.cs
namespace ejercicio08
{
    public class Nodo
    {
        public double Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(double dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}