// ListaEnlazada.cs
using System;

namespace ejercicio08
{
    public class ListaEnlazada
    {
        public Nodo Cabeza { get; private set; }
        public int Count { get; private set; }

        public ListaEnlazada()
        {
            Cabeza = null;
            Count = 0;
        }

        public void Agregar(double dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                Nodo actual = Cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            Count++;
        }

        public double CalcularPromedio()
        {
            if (Cabeza == null)
            {
                return 0.0;
            }

            double suma = 0.0;
            Nodo actual = Cabeza;
            while (actual != null)
            {
                suma += actual.Dato;
                actual = actual.Siguiente;
            }
            return suma / Count;
        }

        public void MostrarLista(string nombreLista)
        {
            Console.Write($"{nombreLista}: [");
            Nodo actual = Cabeza;
            while (actual != null)
            {
                Console.Write($"{actual.Dato}");
                if (actual.Siguiente != null)
                {
                    Console.Write(", ");
                }
                actual = actual.Siguiente;
            }
            Console.WriteLine("]");
        }
    }
}