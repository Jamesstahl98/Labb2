using System.Diagnostics;

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

        Console.SetCursorPosition(Position.X, Position.Y);
        Console.Write(" ");

        int posXDiff = Math.Abs(Position.X - LevelData.Player.Position.X);
        int posYDiff = Math.Abs(Position.Y - LevelData.Player.Position.Y);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
        {
            int xDirectionToPlayer = Math.Sign(LevelData.Player.Position.X - Position.X);
            int yDirectionToPlayer = Math.Sign(LevelData.Player.Position.Y - Position.Y);

            if (posXDiff > posYDiff)
            {
                if (IsFreeSpace(new Position(Position.X + xDirectionToPlayer, Position.Y)))
                {
                    Position = new Position(Position.X + xDirectionToPlayer, Position.Y);
                }
                else if (IsFreeSpace(new Position(Position.X, Position.Y + yDirectionToPlayer)))
                {
                    Position = new Position(Position.X, Position.Y + yDirectionToPlayer);
                }
            }
            else
            {
                if (IsFreeSpace(new Position(Position.X, Position.Y + yDirectionToPlayer)))
                {
                    Position = new Position(Position.X, Position.Y + yDirectionToPlayer);
                }
                else if(IsFreeSpace(new Position(Position.X + xDirectionToPlayer, Position.Y)))
                {
                    Position =new Position(Position.X + xDirectionToPlayer, Position.Y);
                }
            }
        }

        if (IsPlayerNearby() && HP > 0)
        {
            Draw();
        }
    }
}