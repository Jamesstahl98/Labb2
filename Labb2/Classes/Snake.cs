public class Snake : Enemy
{
    public Snake(Position pos, char c, ConsoleColor color) : base(pos, c, color)
    {
        Name = "Snake";
        HP = 25;
        AttackDice = new Dice(3, 4, 2);
        DefenseDice = new Dice(1, 8, 5);
    }

    public override void Update()
    {
        //if(math.abs(player.x, snake.x) < 3)
    }
}