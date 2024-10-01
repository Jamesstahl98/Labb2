using System.Diagnostics;

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
                Debug.WriteLine("armor");
                (element as Player).DefenceDice.Modifier += Amount;
            }
            else
            {
                Debug.WriteLine("attack");
                (element as Player).AttackDice.Modifier += Amount;
            }

            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = element.Color;
            Console.Write($"Player picked up {Name}, increasing {DiceName} modifier by {Amount}.");

            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
            LevelData.Elements.Remove(this);
        }
    }

    public override void Update()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        if (IsPlayerNearby())
        {
            Draw();
        }
    }

    public override void OutOfRange() { }

}