using System;

public class Rat : Enemy
{
    static private Random rand = new Random();
    private enum dir { left, up, right, down};
    Array dirValues = Enum.GetValues(typeof(dir));

    public Rat(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Rat";
        HP = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenseDice = new Dice(1, 6, 1);
    }

    public override void Update()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        dir randomDir = (dir)dirValues.GetValue(rand.Next(dirValues.Length));
        switch(randomDir)
        {
            case dir.left:
                PosX -= 1;
                break;
            case dir.up:
                PosY -= 1;
                break;
            case dir.right:
                PosX += 1;
                break;
            case dir.down:
                PosY += 1;
                break;
        }
        Draw();
    }
}