﻿using System.Diagnostics;

public class Player : Creature
{
    public int Turn { get; set; }
    public Player(Position pos, char c, ConsoleColor color) :base(pos, c, color)
    {
        Turn = 0;
        Name = "Player";
        HP = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenceDice = new Dice(2, 6, 0);
    }

    public void ReadPlayerInput()
    {
        ConsoleKeyInfo cki;
        cki = Console.ReadKey(true);
        if (cki.Key == ConsoleKey.LeftArrow)
        {
            Update(new Position(Position.X - 1, Position.Y));
        }
        else if (cki.Key == ConsoleKey.RightArrow)
        {
            Update(new Position(Position.X + 1, Position.Y));
        }
        else if (cki.Key == ConsoleKey.UpArrow)
        {
            Update(new Position(Position.X, Position.Y - 1));
        }
        else if (cki.Key == ConsoleKey.DownArrow)
        {
            Update(new Position(Position.X, Position.Y + 1));
        }
        else if (cki.Key == ConsoleKey.Escape)
        {
            Environment.Exit(0);
        }
    }

    public void Update(Position newPos)
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(" ");

        UserInterface.ClearLog();

        if (IsFreeSpace(newPos))
        {
            Position = newPos;
            //PosX = newPos.X;
            //PosY = newPos.Y;
        }

        RevealWalls();

        Draw();
    }

    private void RevealWalls()
    {
        IEnumerable<Wall> walls = LevelData.Elements.OfType<Wall>();

        foreach (Wall wall in walls)
        {
            int posXDiff = Math.Abs(Position.X - wall.Position.X);
            int posYDiff = Math.Abs(Position.Y - wall.Position.Y);
            if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
            {
                wall.IsDiscovered = true;
                wall.Draw();
            }
            else
            {
                wall.OutOfRange();
            }
        }
    }
}