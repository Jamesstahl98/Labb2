public class Armor : Item
{
    public int ArmorAmount { get; set; }
    public Armor(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        ArmorAmount = 1;
    }

    public override void ElementContact(Creature element)
    {
        if (element is Player)
        {
            element.DefenseDice.Modifier += ArmorAmount;

            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = element.Color;
            Console.Write($"Player picked up armor, increasing defense modifier by {ArmorAmount}.");

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