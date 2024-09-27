public class Wall : LevelElement
{
    public Wall(Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public override void ElementContact(Character element)
    {
        
    }
}