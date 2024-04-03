using System;

namespace SimpleSnake.GameObjects
{
    public class FoodHash : Food
    {
        public FoodHash(Wall wall) 
            : base(wall, '#', 3, ConsoleColor.Blue)
        {
        }
    }
}