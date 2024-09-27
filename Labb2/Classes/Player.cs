public class Player : Character
{
    public Player(Position pos, char c, ConsoleColor color) :base(pos, c, color)
    {
        HP = 100;
        AttackDice = new Dice(2, 6, 2);
        DefenseDice = new Dice(2, 6, 0);
    }

    public void Update(bool horizontal, int value)
    {
        bool canMove = true;
        Console.SetCursorPosition(PosX, PosY);
        Console.Write(" ");

        if (horizontal)
        {
            for (int i = 0; i < LevelData.Elements.Count; i++)
            {
                if (LevelData.Elements[i].PosX == PosX + value && LevelData.Elements[i].PosY == PosY)
                {
                    LevelData.Elements[i].ElementContact(this);
                    canMove = false;
                }
            }
            if(canMove)
            {
                PosX += value;
            }
        }

        else
        {
            for (int i = 0; i < LevelData.Elements.Count; i++)
            {
                if (LevelData.Elements[i].PosX == PosX && LevelData.Elements[i].PosY == PosY + value)
                {
                    LevelData.Elements[i].ElementContact(this);
                    canMove = false;
                }
            }
            if(canMove)
            {
                PosY += value;
            }
        }
        Draw();
    }
}