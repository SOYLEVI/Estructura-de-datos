// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Random rmd = new Random();

// Definir rango
int inicio = 1;   // valor mínimo
int fin = 500;    // valor máximo

// ---- CONJUNTOS ----
HashSet<string> pf = new HashSet<string>(); // Pfizer
HashSet<string> az = new HashSet<string>(); // AstraZeneca

// ---- Generar 75 aleatorios Pfizer ----
for (int i = 0; i < 75; i++)
{
    int numero = rmd.Next(inicio, fin + 1);
    pf.Add("Ciudadano " + numero);
}

// ---- Generar 75 aleatorios AstraZeneca ----
for (int i = 0; i < 75; i++)
{
    int numero = rmd.Next(inicio, fin + 1);
    az.Add("Ciudadano " + numero);
}

// ---- Intersección (ambas dosis) ----
HashSet<string> ambas = new HashSet<string>(pf);
ambas.IntersectWith(az);

// ---- Solo Pfizer ----
HashSet<string> soloPfizer = new HashSet<string>(pf);
soloPfizer.ExceptWith(az);

// ---- Solo AstraZeneca ----
HashSet<string> soloAstra = new HashSet<string>(az);
soloAstra.ExceptWith(pf);

// ---- No vacunados (U – (P ∪ A)) ----
HashSet<string> todos = new HashSet<string>();
for (int i = inicio; i <= fin; i++)
{
    todos.Add("Ciudadano " + i);
}

HashSet<string> union = new HashSet<string>(pf);
union.UnionWith(az);

HashSet<string> noVacunados = new HashSet<string>(todos);
noVacunados.ExceptWith(union);

// ---- Mostrar resultados ----
Console.WriteLine("\n===== RESULTADOS =====");
Console.WriteLine("Total ciudadanos: " + todos.Count);
Console.WriteLine("Pfizer: " + pf.Count);
Console.WriteLine("AstraZeneca: " + az.Count);
Console.WriteLine("Ambas dosis (P∩A): " + ambas.Count);
Console.WriteLine("Solo Pfizer (P-A): " + soloPfizer.Count);
Console.WriteLine("Solo AstraZeneca (A-P): " + soloAstra.Count);
Console.WriteLine("No vacunados (U-(P∪A)): " + noVacunados.Count);

// ---- Ejemplo: listar algunos ----
Console.WriteLine("\n--- Ejemplo de listados ---");
Console.WriteLine("Pfizer (primeros 10): " + string.Join(", ", pf.Take(10)));
Console.WriteLine("AstraZeneca (primeros 10): " + string.Join(", ", az.Take(10)));
Console.WriteLine("Ambas dosis (todos): " + string.Join(", ", ambas));
Console.WriteLine("No vacunados (primeros 10): " + string.Join(", ", noVacunados.Take(10)));

