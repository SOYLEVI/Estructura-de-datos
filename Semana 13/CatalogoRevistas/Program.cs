using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CatalogoRevistas
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalogo = new RevistaCatalogo();
            catalogo.CargarEjemplos(); // carga 10+ títulos

            while (true)
            {
                Console.WriteLine("\n--- Catálogo de Revistas ---");
                Console.WriteLine("1) Buscar título");
                Console.WriteLine("2) Mostrar catálogo");
                Console.WriteLine("3) Salir");
                Console.Write("Seleccione opción: ");
                var opt = Console.ReadLine()?.Trim();

                if (opt == "1")
                {
                    Console.Write("Ingrese el título a buscar: ");
                    var titulo = Console.ReadLine() ?? "";
                    Console.Write("Buscar con (I)Iterativo o (R)Recursivo [I/R]: ");
                    var metodo = Console.ReadLine()?.Trim().ToUpperInvariant();
                    bool encontrado = false;
                    if (metodo == "R")
                    {
                        encontrado = catalogo.BuscarRecursivo(titulo);
                    }
                    else
                    {
                        encontrado = catalogo.BuscarIterativo(titulo);
                    }
                    Console.WriteLine(encontrado ? "Encontrado" : "No encontrado");
                }
                else if (opt == "2")
                {
                    catalogo.MostrarCatalogo();
                }
                else if (opt == "3")
                {
                    Console.WriteLine("Saliendo...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                }
            }
        }
    }

    /// <summary>
    /// Clase que administra el catálogo de títulos de revistas.
    /// </summary>
    public class RevistaCatalogo
    {
        private List<string> titulos = new List<string>();

        /// <summary>
        /// Carga al menos 10 títulos de ejemplo.
        /// </summary>
        public void CargarEjemplos()
        {
            titulos = new List<string>{
                "Muy Interesante",
                "National Geographic",
                "Forbes",
                "Time",
                "Revista Semana",
                "Scientific American",
                "Quo",
                "Historia y Cultura",
                "PC Magazine",
                "Esquire",
                "El Maletín Científico"
            };
        }

        /// <summary>
        /// Muestra el catálogo por consola.
        /// </summary>
        public void MostrarCatalogo()
        {
            Console.WriteLine("\nTítulos en el catálogo:");
            for (int i = 0; i < titulos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {titulos[i]}");
            }
        }

        /// <summary>
        /// Normaliza un string: quita acentos, pasa a minúsculas.
        /// Esto permite comparar ignorando tildes y mayúsculas.
        /// </summary>
        private static string Normalizar(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return "";
            var formD = s.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in formD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            return sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();
        }

        /// <summary>
        /// Búsqueda iterativa (recorre la lista).
        /// </summary>
        public bool BuscarIterativo(string titulo)
        {
            var tNorm = Normalizar(titulo);
            for (int i = 0; i < titulos.Count; i++)
            {
                if (Normalizar(titulos[i]) == tNorm)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Búsqueda recursiva (envoltorio).
        /// </summary>
        public bool BuscarRecursivo(string titulo)
        {
            return BuscarRecursivoHelper(Normalizar(titulo), 0);
        }

        /// <summary>
        /// Implementación recursiva que avanza por índice.
        /// </summary>
        private bool BuscarRecursivoHelper(string tituloNorm, int index)
        {
            if (index >= titulos.Count) return false;
            if (Normalizar(titulos[index]) == tituloNorm) return true;
            return BuscarRecursivoHelper(tituloNorm, index + 1);
        }
    }
}

