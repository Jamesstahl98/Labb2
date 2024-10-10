public abstract class Item : LevelElement, IInteractable
{
    public Item(Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public abstract void Update();
}