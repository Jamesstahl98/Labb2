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
        UserInterface.ClearLog();
        DamageRoll(element);

        if(HP <= 0)
        {
            return;
        }

        element.DamageRoll(this);
    }

    public void DamageRoll(Creature attacker)
    {
        int damageRoll = attacker.AttackDice.Throw();
        int defenceRoll = DefenceDice.Throw();
        int damage = damageRoll - defenceRoll;

        if (damage < 0)
        {
            damage = 0;
        }
        ChangeHP(-damage);

        UserInterface.PrintCombatLog(attacker, this, damageRoll, defenceRoll, damage);
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
            if (LevelData.Elements[i].Position.X == pos.X && LevelData.Elements[i].Position.Y == pos.Y)
            {
                LevelData.Elements[i].ElementContact(this);
                return false;
            }
        }
        return true;
    }
}