using System.Globalization;
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
            int lineCounter = 0;
            while(!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    int charUnicode = line[i];
                    switch (charUnicode)
                    {
                        case 33:
                            Potion potion = new Potion(new Position(i, lineCounter + 3), '!', ConsoleColor.DarkGreen);
                            _elements.Add(potion);
                            break;
                        case 35:
                            Wall wall = new Wall(new Position(i, lineCounter + 3), '#', ConsoleColor.Gray);
                            _elements.Add(wall);
                            break;
                        case 64:
                            player = new Player(new Position(i, lineCounter + 3), '@', ConsoleColor.Yellow);
                            _elements.Add(player);
                            break;
                        case 97:
                            Armor armor = new Armor(new Position(i, lineCounter + 3), 'a', ConsoleColor.DarkYellow);
                            _elements.Add(armor);
                            break;
                        case 108:
                            Sword sword = new Sword(new Position(i, lineCounter + 3), 'l', ConsoleColor.DarkYellow);
                            _elements.Add(sword);
                            break;
                        case 114:
                            Rat rat = new Rat(new Position(i, lineCounter + 3), 'r', ConsoleColor.Red);
                            _elements.Add(rat);
                            break;
                        case 115:
                            Snake snake = new Snake(new Position(i, lineCounter + 3), 's', ConsoleColor.Green);
                            _elements.Add(snake);
                            break;
                        case 116:
                            Troll troll = new Troll(new Position(i, lineCounter + 3), 't', ConsoleColor.DarkCyan);
                            _elements.Add(troll);
                            break;
                    }
                }
                lineCounter++;
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