public abstract class LevelElement
{
    public Position Pos { get; set; }
    public char Character { get; set; }
    public ConsoleColor Color { get; set; }

    public LevelElement(Position pos, char c, ConsoleColor color)
    {
        Pos = pos;
        Character = c;
        Color = color;
    }
    
    public void Draw()
    {
        Console.SetCursorPosition(Pos.X, Pos.Y);
        Console.Write(Character);
    }
}