using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Verificación de Paréntesis Balanceados ---");

        // Casos de prueba
        string expression1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expression2 = "([{}])";
        string expression3 = "{[()}";
        string expression4 = "((()))";
        string expression5 = "(()";
        string expression6 = "{[(()])]}"; // Esta no está balanceada, hay un error de orden

        Console.WriteLine($"Expresión: {expression1}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression1) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression2}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression2) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression3}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression3) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression4}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression4) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression5}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression5) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression6}");
        Console.WriteLine($"Resultado: {(ParenthesesChecker.AreParenthesesBalanced(expression6) ? "Fórmula balanceada." : "Fórmula NO balanceada.")}\n");

        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
