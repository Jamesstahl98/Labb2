using System;
using System.Diagnostics;

public class Rat : Enemy
{
    static private Random rand = new Random();
    private enum directions { left, up, right, down};
    Array dirValues = Enum.GetValues(typeof(directions));

    public Rat(Position pos, char c, ConsoleColor color) 
        : base(pos, c, color)
    {
        Name = "rat";
        HP = 10;
        AttackDice = new Dice(1, 6, 3);
        DefenceDice = new Dice(1, 6, 1);
    }

    public override void Update()
    {
        if (WasAttackedThisRound)
        {
            WasAttackedThisRound = false;
            return;
        }

        Position newPos = GetRandomPosition(new Position(Position.X, Position.Y));

        if (IsFreeSpace(newPos))
        {
            Move(newPos);
        }

        if (IsPlayerNearby())
        {
            Draw();
        }
    }

    public Position GetRandomPosition(Position position)
    {
        directions randomDirection = (directions)dirValues.GetValue(rand.Next(dirValues.Length));
        switch (randomDirection)
        {
            case directions.left:
                position.X -= 1;
                break;
            case directions.up:
                position.Y -= 1;
                break;
            case directions.right:
                position.X += 1;
                break;
            case directions.down:
                position.Y += 1;
                break;
        }
        return position;
    }
}