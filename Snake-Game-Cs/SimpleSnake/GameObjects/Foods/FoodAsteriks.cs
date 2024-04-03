using System;

namespace SimpleSnake.GameObjects
{
    public class FoodAsteriks : Food
    {
        public FoodAsteriks(Wall wall)
            : base(wall, '*', 1, ConsoleColor.Yellow)
        {
        }
    }
}