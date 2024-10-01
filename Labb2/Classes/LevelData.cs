using System.IO;
using System.Security;

public static class LevelData
{
    private static List<LevelElement> _elements = new List<LevelElement>();

    public static List<LevelElement> Elements { get { return _elements; } }

    public static Player Load(string fileName)
    {
        Player player = null;
        using (StreamReader reader = new StreamReader(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j <= lines[i].Length+1; j++)
                {
                    int charUnicode = reader.Read();
                    if (charUnicode == 33)
                    {
                        Potion potion = new Potion(new Position(j, i + 3), '!', ConsoleColor.DarkGreen);
                        _elements.Add(potion);
                    }
                    if (charUnicode == 35)
                    {
                        Wall wall = new Wall(new Position(j, i + 3), '#', ConsoleColor.Gray);
                        _elements.Add(wall);
                    }
                    else if(charUnicode == 64)
                    {
                        player = new Player(new Position(j, i + 3), '@', ConsoleColor.Yellow);
                        _elements.Add(player);
                    }
                    else if (charUnicode == 97)
                    {
                        Armor armor = new Armor(new Position(j, i + 3), 'a', ConsoleColor.DarkYellow);
                        _elements.Add(armor);
                    }

                    else if (charUnicode == 114)
                    {
                        Rat rat = new Rat(new Position(j, i + 3), 'r', ConsoleColor.Red);
                        _elements.Add(rat);
                    }
                    else if (charUnicode == 115)
                    {
                        Snake snake = new Snake(new Position(j, i + 3), 's', ConsoleColor.Green);
                        _elements.Add(snake);
                    }
                    else if (charUnicode == 116)
                    {
                        Troll troll = new Troll(new Position(j, i + 3), 't', ConsoleColor.DarkCyan);
                        _elements.Add(troll);
                    }
                }
            }
        }

        foreach(LevelElement element in _elements)
        {
            element.PlayerObject = player;
        }

        player.Update(new Position(player.PosX, player.PosY));

        return player;
    }
}