using System.Numerics;

public abstract class LevelElement
{
    public Player PlayerObject { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }
    public bool IsDiscovered { get; set; }

    public LevelElement(Position pos, char c, ConsoleColor color)
    {
        PosX = pos.X;
        PosY = pos.Y;
        Character = c;
        Color = color;
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.ForegroundColor = Color;
        Console.Write(Character);
    }

    public bool CheckIfPlayerNearby()
    {
        int posXDiff = Math.Abs(PosX - PlayerObject.PosX);
        int posYDiff = Math.Abs(PosY - PlayerObject.PosY);
        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public abstract void OutOfRange();

    public abstract void ElementContact(Character element);
}