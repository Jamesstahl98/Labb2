public class Player : LevelElement
{
    public string Name { get; set; }
    public int Health { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenseDice { get; set; }

    public Player(Position pos, char c, ConsoleColor color) :base(pos, c, color)
    {
        Health = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenseDice = new Dice(2, 6, 0);
    }

    public void Update(bool horizontal, int value)
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        if (horizontal)
        {
            PosX += value;
        }

        else
        {
            PosY += value;
        }
        Draw();
    }
}