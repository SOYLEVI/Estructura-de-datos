// Programa.cs
using System;

namespace Ejercicio09
{
    public class Programa
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Ejercicio 09: Comparación de Dos Listas de Enteros ---");

            ListaEnlazada lista1 = new ListaEnlazada();
            ListaEnlazada lista2 = new ListaEnlazada();

            // Carga para la primera lista
            Console.Write("Ingrese la cantidad de datos a cargar en la LISTA 1: ");
            int n1;
            while (!int.TryParse(Console.ReadLine(), out n1) || n1 <= 0)
            {
                Console.Write("Por favor, ingrese un número entero positivo: ");
            }

            for (int i = 0; i < n1; i++)
            {
                Console.Write($"Ingrese el dato entero #{i + 1} para la LISTA 1: ");
                int dato;
                while (!int.TryParse(Console.ReadLine(), out dato))
                {
                    Console.Write("Por favor, ingrese un número entero válido: ");
                }
                lista1.AgregarAlInicio(dato); // Agrega al inicio según el ejercicio
            }

            Console.WriteLine("\n--- Cargando LISTA 2 ---");

            // Carga para la segunda lista
            Console.Write("Ingrese la cantidad de datos a cargar en la LISTA 2: ");
            int n2;
            while (!int.TryParse(Console.ReadLine(), out n2) || n2 <= 0)
            {
                Console.Write("Por favor, ingrese un número entero positivo: ");
            }

            for (int i = 0; i < n2; i++)
            {
                Console.Write($"Ingrese el dato entero #{i + 1} para la LISTA 2: ");
                int dato;
                while (!int.TryParse(Console.ReadLine(), out dato))
                {
                    Console.Write("Por favor, ingrese un número entero válido: ");
                }
                lista2.AgregarAlInicio(dato); // Agrega al inicio según el ejercicio
            }

            Console.WriteLine("\n--- Resultados de la Comparación ---");

            lista1.MostrarLista("LISTA 1");
            lista2.MostrarLista("LISTA 2");

            bool sonIgualesEnContenidoYOrden = lista1.SonIguales(lista2);
            bool mismoTamano = (lista1.Count == lista2.Count);

            if (sonIgualesEnContenidoYOrden)
            {
                Console.WriteLine("a. Las listasEnlazadas son iguales en tamaño y en contenido.");
            }
            else if (mismoTamano && !sonIgualesEnContenidoYOrden)
            {
                Console.WriteLine("b. Las listas son iguales en tamaño pero no en contenido.");
            }
            else
            {
                Console.WriteLine("c. No tienen el mismo tamaño ni contenido.");
            }

            Console.WriteLine("\nPresione cualquier tecla para salir del Ejercicio 09...");
            Console.ReadKey();
        }
    }
}
