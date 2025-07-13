using System.Collections.Generic;

/// <summary>
/// Clase que proporciona métodos para verificar si una expresión tiene paréntesis balanceados.
/// </summary>
public static class ParenthesesChecker
{
    public static bool AreParenthesesBalanced(string expression)
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
                    return false;

                char top = stack.Pop();
                if (!IsMatchingPair(top, c))
                    return false;
            }
        }

        return stack.Count == 0;
    }

    private static bool IsMatchingPair(char open, char close)
    {
        return (open == '(' && close == ')') ||
               (open == '[' && close == ']') ||
               (open == '{' && close == '}');
    }
}
