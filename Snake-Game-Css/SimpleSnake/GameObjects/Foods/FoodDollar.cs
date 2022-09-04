using System;

namespace SimpleSnake.GameObjects
{
    public class FoodDollar : Food
    {
        public FoodDollar(Wall wall)
            : base(wall, '$', 2, ConsoleColor.DarkGreen)
        {
        }
    }
}