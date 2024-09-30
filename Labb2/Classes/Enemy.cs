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
        int damage = DamageRoll(element.AttackDice, DefenseDice);
        if (damage > 0)
        {
            ChangeHP(-damage);
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{Name} took {damage} damage, leaving them with {HP} health");
        }
        else
        {
            Console.SetCursorPosition(0, 1);
            Console.WriteLine($"{Name} took 0 damage, leaving them with {HP} health");
        }


        damage = DamageRoll(DefenseDice, element.DefenseDice);
        if (damage > 0)
        {
            element.ChangeHP(-damage);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{element.Name} took {damage} damage, leaving them with {element.HP} health");
        }
        else
        {
            Console.SetCursorPosition(0, 2);
            Console.WriteLine($"{element.Name} took 0 damage, leaving them with {element.HP} health");
        }
    }
}