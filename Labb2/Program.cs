Player player = new Player(new Position(5, 6), '@', ConsoleColor.Blue);
player.Draw();
ConsoleKeyInfo cki;

do
{
    cki = Console.ReadKey(true);
    if (cki.Key == ConsoleKey.LeftArrow)
    {
        player.Update(true, -1);
    }
    else if (cki.Key == ConsoleKey.RightArrow)
    {
        player.Update(true, 1);
    }
    else if (cki.Key == ConsoleKey.UpArrow)
    {
        player.Update(false, -1);
    }
    else if (cki.Key == ConsoleKey.DownArrow)
    {
        player.Update(false, 1);
    }
} while (cki.Key != ConsoleKey.Escape);