using System.Diagnostics;
using System.Xml.Linq;

public abstract class Creature : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenceDice { get; set; }

    public Creature(Position pos, char c, ConsoleColor color) : base(pos, c, color) { }

    public override void ElementContact(Creature element)
    {
        Console.SetCursorPosition(0, 1);
        DamageRoll(element.AttackDice, DefenceDice, element, this);

        if(HP <= 0)
        {
            return;
        }

        Console.SetCursorPosition(0, 2);
        DamageRoll(AttackDice, element.DefenceDice, this, element);
    }

    public void DamageRoll(Dice attackDice, Dice defenseDice, Creature attacker, Creature defender)
    {
        (int, int) cursorPos = Console.GetCursorPosition();
        int damageRoll = attackDice.Throw();
        int defenseRoll = defenseDice.Throw();
        int damage = damageRoll - defenseRoll;

        if (damage < 0)
        {
            damage = 0;
        }
        defender.ChangeHP(-damage);

        Console.ForegroundColor = attacker.Color;
        Console.SetCursorPosition(cursorPos.Item1, cursorPos.Item2);
        Console.Write($"{attacker.Name} (ATK: {attackDice} => {damageRoll}) attacked {defender.Name} (DEF: {defenseDice} => {defenseRoll}), dealing {damage} damage. ");
        if(defender.HP <= 0)
        {
            Console.Write("Instantly killing it");
        }
        else
        {
            Console.Write($"{defender} has {defender.HP} health left.");
        }
    }

    public void ChangeHP(int amount)
    {
        HP += amount;
        if (HP <= 0)
        {
            RemoveElement();
        }
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