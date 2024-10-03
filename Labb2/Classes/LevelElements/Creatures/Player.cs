using System.Diagnostics;

public class Player : Creature
{
    public int Turn { get; set; }
    public Player(Position pos, char c, ConsoleColor color) :base(pos, c, color)
    {
        Turn = 0;
        Name = "Player";
        HP = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenceDice = new Dice(2, 6, 0);
    }

    public void ReadPlayerInput()
    {
        ConsoleKeyInfo cki;
        do
        {
            cki = Console.ReadKey(true);
            UserInterface.ClearLog();
            if (cki.Key == ConsoleKey.LeftArrow)
            {
                Update(new Position(PosX - 1, PosY));
            }
            else if (cki.Key == ConsoleKey.RightArrow)
            {
                Update(new Position(PosX + 1, PosY));
            }
            else if (cki.Key == ConsoleKey.UpArrow)
            {
                Update(new Position(PosX, PosY - 1));
            }
            else if (cki.Key == ConsoleKey.DownArrow)
            {
                Update(new Position(PosX, PosY + 1));
            }
            Turn++;
            UserInterface.PrintPlayerHPAndTurn(HP, Turn);
            if (HP <= 0)
            {
                UserInterface.GameOver();
                break;
            }
        } while (cki.Key != ConsoleKey.Escape);
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

        RevealWalls();

        Draw();

        foreach (LevelElement element in LevelData.Elements.ToList())
        {
            (element as Enemy)?.Update();
            (element as Item)?.Update();
        }
    }

    private void RevealWalls()
    {
        IEnumerable<Wall> walls = LevelData.Elements.OfType<Wall>();

        foreach (Wall wall in walls)
        {
            int posXDiff = Math.Abs(PosX - wall.PosX);
            int posYDiff = Math.Abs(PosY - wall.PosY);
            if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
            {
                wall.IsDiscovered = true;
                wall.Draw();
            }
            else
            {
                wall.OutOfRange();
            }
        }
    }
}