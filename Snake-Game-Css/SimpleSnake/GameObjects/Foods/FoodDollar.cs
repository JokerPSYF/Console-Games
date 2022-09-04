using System;

namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        public FoodDollar(Wall wall)
            : base(wall, '\u2658', 2, ConsoleColor.DarkGreen)
        {
        }
    }
}