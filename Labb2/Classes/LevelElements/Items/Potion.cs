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
            element.HP += 50;
            if(element.HP>100)
            {
                element.HP = 100;
            }
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