using System.Numerics;

public abstract class LevelElement
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }

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

    public abstract void ElementContact(Character element);
}