using System.Diagnostics;
using System.Xml.Linq;

public class Character : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenseDice { get; set; }

    public Character(Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public override void ElementContact(Character element)
    {
        Console.SetCursorPosition(0, 1);
        int damage = DamageRoll(element.AttackDice, DefenseDice, element, this);
        ChangeHP(-damage);
        Console.Write($" {Name} has {HP} health left.");
        Console.SetCursorPosition(0, 2);
        damage = DamageRoll(AttackDice, element.DefenseDice, this, element);
        element.ChangeHP(-damage);
        Console.Write($" {element.Name} has {element.HP} health left.");
    }

    public int DamageRoll(Dice attackDice, Dice defenseDice, Character attacker, Character defender)
    {
        int damageRoll = attackDice.Throw();
        int defenseRoll = defenseDice.Throw();
        int damage = damageRoll - defenseRoll;

        if (damage < 0)
        {
            damage = 0;
        }
        Console.ForegroundColor = attacker.Color;
        Console.Write($"{attacker.Name} (ATK: {attackDice} => {damageRoll}) attacked {defender.Name} (DEF: {defenseDice} => {defenseRoll}), dealing {damage} damage.");

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
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");
        LevelData.Elements.Remove(this);
    }

    public override void OutOfRange()
    {

    }

    protected bool IsFreeSpace(Position pos)
    {
        for (int i = 0; i < LevelData.Elements.Count; i++)
        {
            if (LevelData.Elements[i] == this)
            {
                continue;
            }
            if (LevelData.Elements[i].PosX == pos.X && LevelData.Elements[i].PosY == pos.Y)
            {
                LevelData.Elements[i].ElementContact(this);
                return false;
            }
        }
        return true;
    }
}