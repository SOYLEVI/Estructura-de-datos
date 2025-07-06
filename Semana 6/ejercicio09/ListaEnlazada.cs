// ListaEnlazada.cs
using System;

namespace Ejercicio09
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

        // Modificado para agregar al inicio
        public void AgregarAlInicio(int dato)
        {
            Nodo nuevoNodo = new Nodo(dato);
            nuevoNodo.Siguiente = Cabeza;
            Cabeza = nuevoNodo;
            Count++;
        }

        public bool SonIguales(ListaEnlazada otraLista)
        {
            if (this.Count != otraLista.Count)
            {
                return false; // Diferente tamaño
            }

            Nodo actualThis = this.Cabeza;
            Nodo actualOtra = otraLista.Cabeza;

            while (actualThis != null && actualOtra != null)
            {
                if (actualThis.Dato != actualOtra.Dato)
                {
                    return false; // Diferente contenido en el mismo orden
                }
                actualThis = actualThis.Siguiente;
                actualOtra = actualOtra.Siguiente;
            }
            return true; // Son iguales en tamaño y contenido
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