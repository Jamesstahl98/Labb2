public class Potion : Item
{
    public int HPRestore { get; set; }
    public Potion(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        HPRestore = 50;
    }

    public override void ElementContact(Creature element)
    {
        if(element is Player)
        {
            element.HP += HPRestore;
            if(element.HP>100)
            {
                element.HP = 100;
            }

            Console.SetCursorPosition(0, 1);
            Console.ForegroundColor = element.Color;
            Console.Write($"Player picked up potion, restoring {HPRestore} health.");

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
}