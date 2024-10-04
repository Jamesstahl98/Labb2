using static System.Net.Mime.MediaTypeNames;

public static class UserInterface
{
    private static readonly List<string> combatLogEntries = new List<string>();

    public static void PrintPlayerHPAndTurn(int health, int turn)
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.SetCursorPosition(0, 0);
        Console.Write($"Turn: {turn}, Player Health: {health}");
    }

    public static void PrintCombatLog(Creature attacker, Creature defender, int attackRoll, int defenceRoll, int damage)
    {
        combatLogEntries.Add($"{attacker.Name} (ATK: {attacker.AttackDice} => {attackRoll}) " +
            $"attacked {defender.Name} " +
            $"(DEF: {defender.DefenceDice} => {defenceRoll}), " +
            $"dealing {damage} damage. ");

        Console.SetCursorPosition(0, combatLogEntries.Count);
        Console.ForegroundColor = attacker.Color;

        Console.Write(combatLogEntries[combatLogEntries.Count-1]);

        if (defender.HP <= 0)
        {
            Console.Write("Instantly killing it");
        }
        else
        {
            Console.Write($"{defender} has {defender.HP} health left.");
        }
    }

    public static void ClearLog()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 2);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    public static void ClearCombatLog()
    {
        combatLogEntries.Clear();
        Console.SetCursorPosition(0, 1);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 2);
        Console.Write(new string(' ', Console.WindowWidth));
    }

    public static void GameOver()
    {
        ClearLog();
        Console.SetCursorPosition(0, 0);
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write("You died :(");
        Console.ReadKey();
    }
}