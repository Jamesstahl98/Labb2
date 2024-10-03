﻿public class Troll : Enemy
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

        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        int posXDiff = Math.Abs(PosX - LevelData.Player.PosX);
        int posYDiff = Math.Abs(PosY - LevelData.Player.PosY);

        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
        {
            int xDirectionToPlayer = Math.Sign(LevelData.Player.PosX - PosX);
            int yDirectionToPlayer = Math.Sign(LevelData.Player.PosY - PosY);

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