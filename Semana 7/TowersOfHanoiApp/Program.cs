 // Imprime el estado actual de todas las torres
    private static void PrintTowers()
    {
        Console.WriteLine("--- Torres ---");
        Console.WriteLine($"Tower A: {string.Join(", ", towerA.Reverse())}");
        Console.WriteLine($"Tower B: {string.Join(", ", towerB.Reverse())}");
        Console.WriteLine($"Tower C: {string.Join(", ", towerC.Reverse())}");
        Console.WriteLine("--------------\n");
    }

    // Obtiene el nombre de la torre para fines de impresión
    private static string GetName(Stack<int> tower)
    {
        if (tower == towerA) return "Tower A";
        if (tower == towerB) return "Tower B";
        if (tower == towerC) return "Tower C";
        return "Unknown Tower";
    }
