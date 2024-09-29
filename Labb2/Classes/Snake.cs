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
        foreach(LevelElement element in LevelData.Elements)
        {
            if(element is Player)
            {
                int posXDiff = Math.Abs(PosX - element.PosX);
                int posYDiff = Math.Abs(PosY - element.PosY);

                if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 4)
                {
                    var newPos = new Position(PosX, PosY);

                    if (posXDiff>posYDiff)
                    {
                        newPos.X += Math.Sign(PosX - element.PosX);
                    }
                    else
                    {
                        newPos.Y += Math.Sign(PosY - element.PosY);
                    }
                    if (IsFreeSpace(newPos))
                    {
                        Console.SetCursorPosition(PosX, PosY);
                        Console.Write(" ");
                        PosX = newPos.X;
                        PosY = newPos.Y;
                    }
                    Draw();
                }
            }
        }
    }
}