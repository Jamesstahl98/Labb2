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

        (int posXDistance, int posYDistance) = GetXAndYDistanceToElement(LevelData.Player.Position);

        Position newPos = GetNewPosition(posXDistance, posYDistance);

        var collider = GetLevelElementCollision(newPos);
        if (collider is null or Player)
        {
            Move(newPos, collider);
        }

        if (IsPlayerNearby())
        {
            Draw();
        }
    }

    private Position GetNewPosition(int posXDistance, int posYDistance)
    {
        if ((posXDistance * posXDistance) + (posYDistance * posYDistance) >= 9)
        {
            return Position;
        }
        
        var newPos = new Position(Position.X, Position.Y);

        if (posXDistance > posYDistance)
        {
            newPos.X += Math.Sign(Position.X - LevelData.Player.Position.X);
        }
        else
        {
            newPos.Y += Math.Sign(Position.Y - LevelData.Player.Position.Y);
        }
        return newPos;
    }
}