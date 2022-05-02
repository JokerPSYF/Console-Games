using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSnake.Utilities;

namespace SimpleSnake.GameObjects
{
    public abstract class Food : Point
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;
        private ConsoleColor color;

        protected Food(Wall wall, char symbol, int points, ConsoleColor color)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            foodSymbol = symbol;
            FoodPoints = points;
            random = new Random();
            this.color = color;
        }

        public int FoodPoints { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = random.Next(2, wall.LeftX - 2);
            this.TopY = random.Next(2, wall.TopY - 2);

            //this.LeftX = random.Next(1, wall.LeftX - 1);
            //this.TopY = random.Next(0, wall.TopY);

            bool isPointOfSnake = snakeElements
                .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);

            while (isPointOfSnake)
            {
                this.LeftX = random.Next(2, wall.LeftX - 2);
                this.TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElements
                    .Any(x => x.LeftX == this.LeftX && x.TopY == this.TopY);
            }

            Console.BackgroundColor = color;
            Console.ForegroundColor = ConsoleColor.Black;

            this.Draw(foodSymbol);
               Console.BackgroundColor = ConsoleWindow.BgColor;
            Console.ForegroundColor = ConsoleWindow.FgColor;
        }

        public bool IsFoodPoint(Point snake)
            => snake.TopY == this.TopY && snake.LeftX == this.LeftX;
    }
}