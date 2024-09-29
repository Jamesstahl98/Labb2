using System.Diagnostics;

public class Character : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenseDice { get; set; }

    public Character(Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public override void ElementContact(Character element)
    {
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

    public int DamageRoll(Dice attackDice, Dice defenseDice)
    {
        int damageRoll = attackDice.Throw();
        int defenseRoll = defenseDice.Throw();
        int damage = damageRoll - defenseRoll;

        return damage;
    }

    public void ChangeHP(int amount)
    {
        HP += amount;
        if (HP <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        LevelData.Elements.Remove(this);
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");
    }

    public override void OutOfRange()
    {
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");
    }

    protected bool IsFreeSpace(Position pos)
    {
        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            if (LevelData.Elements[i].PosX == pos.X && LevelData.Elements[i].PosY == pos.Y)
            {
                LevelData.Elements[i].ElementContact(this);
                return false;
            }
        }
        return true;
    }
}