using System.Diagnostics;

public abstract class Enemy : Character
{
    public Enemy( Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public abstract void Update();

    public override void ElementContact(Character element)
    {
        if (element != PlayerObject)
        {
            return;
        }
        else
        {
            base.ElementContact(element);
        }
    }
}