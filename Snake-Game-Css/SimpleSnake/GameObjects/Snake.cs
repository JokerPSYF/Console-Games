using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using SimpleSnake.Enums;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char bodySymbol = Characters.bodySymbol; // classic ball
        private const char snakeSymbol = Characters.snakeSymbol; // smileyface
        private const char verticalSymbol = Characters.verticalSymbol; // vertical
        private const char horizontalSymbol = Characters.horizontalSymbol; // horizontal

        private Wall wall;
        private Queue<Point> snakeElements;
        private Point snakeHead;
        private Food[] foods;
        private int foodIndex;
        private int nextLeftX; 
        private int nextTopY;
        private Food food;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new Queue<Point>();
            this.foods = new Food[3];
            this.foodIndex = RandomFoodNumber;
            this.GetsFoods();
            this.CreateSnake();
            this.food = foods[RandomFoodNumber];
            food.SetRandomPosition(snakeElements);
            Score = 0;
        }

        public int Score { get; private set; }

        private int RandomFoodNumber
            => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            Point currSnakeHead = this.snakeHead;

            GetNextPoint(direction, currSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake) return false;

            Point oldHead = this.snakeHead;
            this.snakeHead = new Point(this.nextLeftX, this.nextTopY);

            if (this.wall.IsPointOfWall(snakeHead)) return false;

            this.snakeElements.Enqueue(oldHead);

            oldHead.Draw(direction.TopY == 0 ? horizontalSymbol : verticalSymbol);

            this.snakeHead.Draw(snakeSymbol);

            if (food.IsFoodPoint(snakeHead))
            {
                this.Eat(direction, currSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();

            snakeTail.Draw(' ');

            return true;
        }
        private void CreateSnake()
        {
           
            for (int topY = 1; topY <= 5; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
            snakeHead = new Point(2, 6);
        }

        private void GetsFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodAsteriks(this.wall);
            this.foods[2] = new FoodDollar(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }

        private void Eat(Point direction, Point currSnakeHead)
        {
            int length = foods[foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currSnakeHead);
            }

            Score += food.FoodPoints;

            this.foodIndex = this.RandomFoodNumber;
            this.food = this.foods[foodIndex];
            food.SetRandomPosition(this.snakeElements);
        }
    }
}