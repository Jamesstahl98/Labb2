using System.Diagnostics;
using System.Xml.Linq;

public class Snake : Enemy
{
    public Snake(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Snake";
        HP = 25;
        AttackDice = new Dice(3, 4, 2);
        DefenceDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        if(WasAttackedThisRound)
        {
            WasAttackedThisRound = false;
            return;
        }

        int posXDiff = Math.Abs(PosX - LevelData.Player.PosX);
        int posYDiff = Math.Abs(PosY - LevelData.Player.PosY);

        var newPos = new Position(PosX, PosY);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 9)
        {

            if (posXDiff>posYDiff)
            {
                newPos.X += Math.Sign(PosX - LevelData.Player.PosX);
            }
            else
            {
                newPos.Y += Math.Sign(PosY - LevelData.Player.PosY);
            }
        }
        if (IsFreeSpace(newPos))
        {
            Console.SetCursorPosition(PosX, PosY);
            Console.Write(" ");
            PosX = newPos.X;
            PosY = newPos.Y;
        }
        if (IsPlayerNearby())
        {
            Draw();
        }
    }
}