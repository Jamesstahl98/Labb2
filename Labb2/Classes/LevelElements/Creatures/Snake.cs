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

        int posXDiff = Math.Abs(Position.X - LevelData.Player.Position.X);
        int posYDiff = Math.Abs(Position.Y - LevelData.Player.Position.Y);

        var newPos = new Position(Position.X, Position.Y);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 9)
        {

            if (posXDiff>posYDiff)
            {
                newPos.X += Math.Sign(Position.X - LevelData.Player.Position.X);
            }
            else
            {
                newPos.Y += Math.Sign(Position.Y - LevelData.Player.Position.Y);
            }
        }
        if (IsFreeSpace(newPos))
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(" ");
            Position = newPos;
        }
        if (IsPlayerNearby())
        {
            Draw();
        }
    }
}