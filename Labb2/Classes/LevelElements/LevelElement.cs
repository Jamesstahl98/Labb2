using System.Numerics;

public abstract class LevelElement
{
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

    public void RemoveElement()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");
        LevelData.Elements.Remove(this);
    }

    public bool IsPlayerNearby()
    {
        int posXDiff = Math.Abs(PosX - LevelData.Player.PosX);
        int posYDiff = Math.Abs(PosY - LevelData.Player.PosY);
        if ((posXDiff * posXDiff) + (posYDiff * posYDiff) < 25)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public abstract void ElementContact(Creature element);
}