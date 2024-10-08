﻿using System.Diagnostics;

public abstract class DiceModifierItem : Item
{
    public int Amount { get; set; }
    public string DiceType { get; set; }
    public string DiceName { get; set; }
    public string Name { get; set; }

    public DiceModifierItem(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {

    }

    public override void ElementContact(Creature element)
    {
        if (element is Player)
        {
            if(DiceType == "defence")
            {
                ((Player)element).DefenceDice.Modifier += Amount;
            }
            else
            {
                ((Player)element).AttackDice.Modifier += Amount;
            }

            UserInterface.PrintItemPickup(this);

            RemoveElement();
        }
    }

    public override void Update()
    {
        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(" ");

        if (IsPlayerNearby())
        {
            Draw();
        }
    }

    public override string ToString()
    {
        return $"Player picked up {Name}, " +
                $"increasing {DiceName} " +
                $"by {Amount}.";

    }
}