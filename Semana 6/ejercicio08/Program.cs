// Programa.cs
using System;

namespace Ejercicio8
{
    public class Programa
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- Ejercicio 8: Procesamiento de Datos Reales en Listas ---");

            ListaEnlazada listaPrincipal = new ListaEnlazada();
            Console.Write("Ingrese la cantidad de datos a cargar en la lista principal: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Por favor, ingrese un número entero positivo: ");
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Ingrese el dato real #{i + 1}: ");
                double dato;
                while (!double.TryParse(Console.ReadLine(), out dato))
                {
                    Console.Write("Por favor, ingrese un número real válido: ");
                }
                listaPrincipal.Agregar(dato);
            }

            Console.WriteLine("\n--- Resultados ---");

            // a. Los datos cargados en la lista principal.
            listaPrincipal.MostrarLista("Datos en la lista principal");

            // b. El promedio.
            double promedio = listaPrincipal.CalcularPromedio();
            Console.WriteLine($"El promedio de los datos es: {promedio:F2}"); // Formatear a 2 decimales

            // c. Los datos cuyo valor sea igual o menor al promedio de todos los datos.
            ListaEnlazada listaMenoresIguales = new ListaEnlazada();
            ListaEnlazada listaMayores = new ListaEnlazada();

            Nodo actual = listaPrincipal.Cabeza;
            while (actual != null)
            {
                if (actual.Dato <= promedio)
                {
                    listaMenoresIguales.Agregar(actual.Dato);
                }
                else
                {
                    listaMayores.Agregar(actual.Dato);
                }
                actual = actual.Siguiente;
            }

            listaMenoresIguales.MostrarLista("Datos menores o iguales al promedio");

            // d. Los datos que sean mayores al promedio de todos los datos.
            listaMayores.MostrarLista("Datos mayores al promedio");

            Console.WriteLine("\nPresione cualquier tecla para salir del ejercicio 08...");
            Console.ReadKey();
        }
    }
}