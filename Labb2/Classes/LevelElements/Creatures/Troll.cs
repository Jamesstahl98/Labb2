public class Troll : Enemy
{
    public Troll(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Troll";
        HP = 25;
        AttackDice = new Dice(4, 5, 1);
        DefenceDice = new Dice(1, 4, 2);
    }

    public override void Update()
    {
        if (WasAttackedThisRound)
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

        if (IsPlayerNearby() && HP > 0)
        {
            Draw();
        }
    }

    public Position GetNewPosition(int posXDistance, int posYDistance)
    {
        if((posXDistance * posXDistance) + (posYDistance * posYDistance) >= 25)
        {
            return Position;
        }

        int xDirectionToPlayer = Math.Sign(LevelData.Player.Position.X - Position.X);
        int yDirectionToPlayer = Math.Sign(LevelData.Player.Position.Y - Position.Y);

        if (posXDistance > posYDistance)
        {
            if (GetLevelElementCollision(new Position(Position.X + xDirectionToPlayer, Position.Y)) is null or Player)
            {
                return new Position(Position.X + xDirectionToPlayer, Position.Y);
            }

            else if (GetLevelElementCollision(new Position(Position.X, Position.Y + yDirectionToPlayer)) is null or Player)
            {
                return new Position(Position.X, Position.Y + yDirectionToPlayer);
            }
        }
        else
        {
            if (GetLevelElementCollision(new Position(Position.X, Position.Y + yDirectionToPlayer)) is null or Player)
            {
                return new Position(Position.X, Position.Y + yDirectionToPlayer);
            }
            else if (GetLevelElementCollision(new Position(Position.X + xDirectionToPlayer, Position.Y)) is null or Player)
            {
                return new Position(Position.X + xDirectionToPlayer, Position.Y);
            }
        }
        return Position;
    }
}