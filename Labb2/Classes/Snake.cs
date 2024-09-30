using System.Diagnostics;
using System.Xml.Linq;

public class Snake : Enemy
{
    public Snake(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Snake";
        HP = 25;
        AttackDice = new Dice(3, 4, 2);
        DefenseDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        int posXDiff = Math.Abs(PosX - PlayerObject.PosX);
        int posYDiff = Math.Abs(PosY - PlayerObject.PosY);

        var newPos = new Position(PosX, PosY);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 3)
        {

            if (posXDiff>posYDiff)
            {
                newPos.X += Math.Sign(PosX - PlayerObject.PosX);
            }
            else
            {
                newPos.Y += Math.Sign(PosY - PlayerObject.PosY);
            }
        }
        if (IsFreeSpace(newPos))
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
            PosX = newPos.X;
            PosY = newPos.Y;
        }
        if (CheckIfPlayerNearby())
        {
            Draw();
        }
        else
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
        }
    }
}