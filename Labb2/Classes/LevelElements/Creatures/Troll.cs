public class Troll : Enemy
{
    public Troll(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Troll";
        HP = 25;
        AttackDice = new Dice(4, 5, 1);
        DefenseDice = new Dice(1, 4, 2);
    }

    public override void Update()
    {
        if (WasAttackedThisRound)
        {
            WasAttackedThisRound = false;
            return;
        }

        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        int posXDiff = Math.Abs(PosX - PlayerObject.PosX);
        int posYDiff = Math.Abs(PosY - PlayerObject.PosY);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
        {
            int xDirectionToPlayer = Math.Sign(PlayerObject.PosX - PosX);
            int yDirectionToPlayer = Math.Sign(PlayerObject.PosY - PosY);

            if (posXDiff > posYDiff)
            {
                if (IsFreeSpace(new Position(PosX + xDirectionToPlayer, PosY)))
                {
                    PosX += xDirectionToPlayer;
                }
                else if (IsFreeSpace(new Position(PosX, PosY + yDirectionToPlayer)))
                {
                    PosY += yDirectionToPlayer;
                }
            }
            else
            {
                if (IsFreeSpace(new Position(PosX, PosY + yDirectionToPlayer)))
                {
                    PosY += yDirectionToPlayer;
                }
                else if(IsFreeSpace(new Position(PosX + xDirectionToPlayer, PosY)))
                {
                    PosX += xDirectionToPlayer;
                }
            }
        }

        if (IsPlayerNearby() && HP > 0)
        {
            Draw();
        }
    }
}