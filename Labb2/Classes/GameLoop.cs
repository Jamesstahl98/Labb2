public static class GameLoop
{
    public static int TurnCounter { get; set; }

    public static void Start()
    {
        Console.CursorVisible = false;
        LevelData.Load("Level1.txt");

        while(LevelData.Player.HP > 0)
        {
            UserInterface.PrintPlayerHPAndTurn(LevelData.Player.HP, TurnCounter);
            LevelData.Player.ReadPlayerInput();
            UpdateEnemies();
            TurnCounter++;
        }
        UserInterface.GameOver();
    }

    private static void UpdateEnemies()
    {
        foreach (LevelElement element in LevelData.Elements.ToList())
        {
            (element as Enemy)?.Update();
            (element as Item)?.Update();
        }
    }
}