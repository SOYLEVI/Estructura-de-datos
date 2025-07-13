using System;
using System.Collections.Generic;

public class ParenthesisChecker
{
    public static void Main(string[] args)
    {
        string expression1 = "{7 + (8 * 5) - [(9 - 7) + (4 + 1)]}";
        string expression2 = "{[()]}}";
        string expression3 = "(()";
        string expression4 = "{[()]}";

        Console.WriteLine($"Expresión: {expression1}");
        Console.WriteLine($"Resultado: {(IsBalanced(expression1) ? "Fórmula balanceada." : "Fórmula no balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression2}");
        Console.WriteLine($"Resultado: {(IsBalanced(expression2) ? "Fórmula balanceada." : "Fórmula no balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression3}");
        Console.WriteLine($"Resultado: {(IsBalanced(expression3) ? "Fórmula balanceada." : "Fórmula no balanceada.")}\n");

        Console.WriteLine($"Expresión: {expression4}");
        Console.WriteLine($"Resultado: {(IsBalanced(expression4) ? "Fórmula balanceada." : "Fórmula no balanceada.")}\n");
    }

    public static bool IsBalanced(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(' || c == '{' || c == '[')
            {
                stack.Push(c);
            }
            else if (c == ')' || c == '}' || c == ']')
            {
                if (stack.Count == 0)
                {
                    return false; // Paréntesis de cierre sin uno de apertura
                }

                char lastOpen = stack.Pop();

                if ((c == ')' && lastOpen != '(') ||
                    (c == '}' && lastOpen != '{') ||
                    (c == ']' && lastOpen != '['))
                {
                    return false; // No coinciden los tipos de paréntesis
                }
            }
        }

        return stack.Count == 0; // Si la pila está vacía, todos los paréntesis están balanceados
    }
}