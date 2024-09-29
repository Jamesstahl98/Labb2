using System.Diagnostics;

public class Player : Character
{
    public Player(Position pos, char c, ConsoleColor color) :base(pos, c, color)
    {
        HP = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenseDice = new Dice(2, 6, 0);
    }

    public void Update(Position newPos)
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        if(IsFreeSpace(newPos))
        {
            PosX = newPos.X;
            PosY = newPos.Y;
        }

        RevealLevelElements();

        Draw();

        foreach(LevelElement element in LevelData.Elements.ToList())
        {
            (element as Enemy)?.Update();
        }
    }

    private void RevealLevelElements()
    {
        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            int posXDiff = Math.Abs(PosX - LevelData.Elements[i].PosX);
            int posYDiff = Math.Abs(PosY - LevelData.Elements[i].PosY);
            if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
            {
                LevelData.Elements[i].IsDiscovered = true;
                LevelData.Elements[i].Draw();
            }
            else
            {
                if (LevelData.Elements[i].IsDiscovered == true)
                {
                    LevelData.Elements[i].OutOfRange();
                }
            }
        }
    }

    public override void ElementContact(Character element)
    {
        int damage = DamageRoll(element.AttackDice, DefenseDice);

        if (damage > 0)
        {
            ChangeHP(-damage);
        }

        damage = DamageRoll(DefenseDice, element.DefenseDice);
        if (damage > 0)
        {
            element.ChangeHP(-damage);
        }
    }
}