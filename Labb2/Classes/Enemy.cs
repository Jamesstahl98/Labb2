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
        }

        damage = DamageRoll(DefenseDice, element.DefenseDice);
        if (damage > 0)
        {
            element.ChangeHP(-damage);
        }
    }
}