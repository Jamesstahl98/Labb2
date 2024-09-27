public abstract class Enemy : LevelElement
{
    public string Name { get; set; }
    public int HP { get; set; }
    public Dice AttackDice { get; set; }
    public Dice DefenseDice { get; set; }

    public Enemy(string name, int maxHP, Dice attackDice, Dice defenseDice, 
        Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = name;
        HP = maxHP;
        AttackDice = attackDice;
        DefenseDice = defenseDice;
    }

    public abstract void Update();
}