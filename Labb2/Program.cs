﻿int turn = 0;
Console.CursorVisible = false;
Player player = LevelData.Load("Level1.txt");

ConsoleKeyInfo cki;
do
{
    cki = Console.ReadKey(true);
    ClearLog();
    if (cki.Key == ConsoleKey.LeftArrow)
    {
        player.Update(new Position(player.PosX-1, player.PosY));
    }
    else if (cki.Key == ConsoleKey.RightArrow)
    {
        player.Update(new Position(player.PosX + 1, player.PosY));
    }
    else if (cki.Key == ConsoleKey.UpArrow)
    {
        player.Update(new Position(player.PosX, player.PosY-1));
    }
    else if (cki.Key == ConsoleKey.DownArrow)
    {
        player.Update(new Position(player.PosX, player.PosY+1));
    }
    turn++;
    PrintPlayerHPAndTurn(player.HP, turn);
    if(player.HP <= 0)
    {
        GameOver();
        break;
    }
} while (cki.Key != ConsoleKey.Escape);

static void PrintPlayerHPAndTurn(int health, int turn)
{
    Console.ForegroundColor = ConsoleColor.Gray;
    Console.SetCursorPosition(0, 0);
    Console.Write($"Turn: {turn}, Player Health: {health}");
}

static void ClearLog()
{
    Console.SetCursorPosition(0, 0);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, 1);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, 2);
    Console.Write(new string(' ', Console.WindowWidth));
}

static void GameOver()
{
    ClearLog();
    Console.SetCursorPosition(0, 0);
    Console.Write("You died :(");
    Console.ReadKey();
}