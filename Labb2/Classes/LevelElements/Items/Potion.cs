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
}