﻿using System;
using System.Diagnostics;

public class Rat : Enemy
{
    static private Random rand = new Random();
    private enum dir { left, up, right, down};
    Array dirValues = Enum.GetValues(typeof(dir));

    public Rat(Position pos, char c, ConsoleColor color) 
        : base(pos, c, color)
    {
        Name = "rat";
        HP = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }

    public override void Update()
    {
        if (WasAttackedThisRound)
        {
            WasAttackedThisRound = false;
            return;
        }

        var newPos = new Position(Position.X, Position.Y);

        dir randomDir = (dir)dirValues.GetValue(rand.Next(dirValues.Length));
        switch(randomDir)
        {
            case dir.left:
                newPos.X -= 1;
                break;
            case dir.up:
                newPos.Y -= 1;
                break;
            case dir.right:
                newPos.X += 1;
                break;
            case dir.down:
                newPos.Y += 1;
                break;
        }

        if (IsFreeSpace(newPos))
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
            Position = newPos;
            if(IsPlayerNearby())
            {
                Draw();
            }
        }
    }
}