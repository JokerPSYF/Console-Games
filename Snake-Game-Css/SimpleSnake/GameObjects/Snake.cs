using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char bodySymbol = Characters.BodySymbol; // classic ball
        private const char snakeSymbol = Characters.SnakeSymbol; // smileyface
        private const char verticalSymbol = Characters.VerticalSymbol; // vertical
        private const char horizontalSymbol = Characters.HorizontalSymbol; // horizontal
        public const char downRightSymbol = Characters.DownRightSymbol; // down right
        public const char downLeftSymbol = Characters.DownLeftSymbol; // down left
        public const char UpLeftSymbol = Characters.UpLeftSymbol; // up left
        public const char UpRightSymbol = Characters.UpRightSymbol; // up right

        private Wall wall;
        private List<Point> snakeElements;
        private Point snakeHead;
        private Food[] foods;
        private int foodIndex;
        private int nextLeftX;
        private int nextTopY;
        private Food food;

        public Snake(Wall wall)
        {
            this.wall = wall;
            this.snakeElements = new List<Point>();
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

            this.snakeElements.Add(oldHead);

            this.currChar = ChangeSymbol(oldHead, this.snakeHead, snakeElements[snakeElements.Count - 2]);

            oldHead.Draw(this.currChar);

            this.snakeHead.Draw(snakeSymbol);

            if (food.IsFoodPoint(snakeHead))
            {
                this.Eat(direction, currSnakeHead);
            }

            Point snakeTail = snakeElements.First();
            snakeElements.Remove(snakeElements.First());

            snakeTail.Draw(' ');

            return true;
        }
        private void CreateSnake()
        {

            for (int topY = 1; topY <= 5; topY++)
            {
                snakeElements.Add(new Point(2, topY));
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
                this.snakeElements.Add(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, currSnakeHead);
            }

            Score += food.FoodPoints;

            this.foodIndex = this.RandomFoodNumber;
            this.food = this.foods[foodIndex];
            food.SetRandomPosition(this.snakeElements);
        }

        private char ChangeSymbol(Point oldDirection, Point newDirecrion, Point snakeElement)
        {
            char symbol = this.currChar;
            while (oldDirection.TopY == snakeElement.TopY && oldDirection.LeftX == snakeElement.LeftX)
            {
                int index = this.snakeElements.IndexOf(snakeElement);
                snakeElement = this.snakeElements[index - 1];
            }
            //Check if were going UP
            if (snakeElement.TopY > oldDirection.TopY)
            {
                //Check if we going right
                if (oldDirection.LeftX < newDirecrion.LeftX)
                {
                    symbol = Characters.DownRightSymbol;
                }
                //Check if we going left
                else if (oldDirection.LeftX > newDirecrion.LeftX)
                {
                    symbol = Characters.DownLeftSymbol;
                }
                else
                {
                    symbol = Characters.VerticalSymbol;
                }
            }
            //Check if were going down
            else if (snakeElement.TopY < oldDirection.TopY)
            {
                //Check if we going right
                if (oldDirection.LeftX < newDirecrion.LeftX)
                {
                    symbol = Characters.UpRightSymbol;
                }
                //Check if we going left
                else if (oldDirection.LeftX > newDirecrion.LeftX)
                {
                    symbol = Characters.UpLeftSymbol;
                }
                else
                {
                    symbol = Characters.VerticalSymbol;
                }
            }
            //Check if were going left
            else if (snakeElement.LeftX > oldDirection.LeftX)
            {
                //Check if we going up
                if (oldDirection.TopY > newDirecrion.TopY)
                {
                    symbol = Characters.UpRightSymbol;
                }
                //Check if we going down
                else if (oldDirection.TopY < newDirecrion.TopY)
                {
                    symbol = Characters.DownRightSymbol;
                }
                else
                {
                    symbol = Characters.HorizontalSymbol;
                }
            }
            //Check if were going right
            else if (snakeElement.LeftX < oldDirection.LeftX)
            {
                //Check if we going up
                if (oldDirection.TopY > newDirecrion.TopY)
                {
                    symbol = Characters.UpLeftSymbol;
                }
                //Check if we going down
                else if (oldDirection.TopY < newDirecrion.TopY)
                {
                    symbol = Characters.DownLeftSymbol;
                }
                else
                {
                    symbol = Characters.HorizontalSymbol;
                }
            }
            return symbol;
        }
    }
}