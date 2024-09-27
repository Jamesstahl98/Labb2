﻿using System.IO;
using System.Security;

public static class LevelData
{
    private static List<LevelElement> _elements = new List<LevelElement>();

    public static List<LevelElement> Elements { get { return _elements; } }

    public static void Load(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j <= lines[i].Length+1; j++)
                {
                    int charUnicode = reader.Read();
                    if (charUnicode == 35)
                    {
                        Wall wall = new Wall(new Position(j, i), '#', ConsoleColor.Gray);
                        _elements.Add(wall);
                    }
                    else if(charUnicode == 64)
                    {
                        Player player = new Player(new Position(j, i), '@', ConsoleColor.Gray);
                        _elements.Add(player);
                    }
                    else if (charUnicode == 114)
                    {
                        Rat rat = new Rat(new Position(j, i), 'r', ConsoleColor.Red);
                        _elements.Add(rat);
                    }
                    else if (charUnicode == 115)
                    {
                        Snake snake = new Snake(new Position(j, i), 's', ConsoleColor.Green);
                        _elements.Add(snake);
                    }
                }
                Console.WriteLine();
            }
        }
        foreach (LevelElement element in Elements)
        {
            element.Draw();
        }
    }
}