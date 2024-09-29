Console.CursorVisible = false;
Player player = LevelData.Load("Level1.txt");

ConsoleKeyInfo cki;
do
{
    cki = Console.ReadKey(true);
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
} while (cki.Key != ConsoleKey.Escape);