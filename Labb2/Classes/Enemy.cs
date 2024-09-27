public abstract class Enemy : Character
{
    public Enemy( Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public abstract void Update();
}