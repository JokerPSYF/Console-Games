using System;
using System.Threading;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Wall wall;
        private Snake snake;
        private Point[] pointsOfDirections;
        private double sleepTime;
        private Direction direction;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            sleepTime = 100;
            pointsOfDirections = new Point[4];
        }

        private void CreateDirections()
        {
            this.pointsOfDirections[0] = new Point(1, 0);
            this.pointsOfDirections[1] = new Point(-1, 0);
            this.pointsOfDirections[2] = new Point(0, 1);
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                ShowScore();
                if (Console.KeyAvailable)
                {
                    GetNextDirections();
                }

                bool isMoving = snake.IsMoving(this.pointsOfDirections[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;
                if (sleepTime < 0) sleepTime = 0;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void GetNextDirections()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);

            switch (userInput.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    if (direction != Direction.Right)
                    {
                        direction = Direction.Left;
                    }
                    break;

                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    if (direction != Direction.Left)
                    {
                        direction = Direction.Right;
                    }
                    break;

                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    if (direction != Direction.Down)
                    {
                        direction = Direction.Up;
                    }
                    break;

                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    if (direction != Direction.Up )
                    {
                        direction = Direction.Down;
                    }
                    break;
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = this.wall.LeftX + 1;
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.Y)
            {
                Console.Clear();
                StartUp.Main();
            }
            else if (input.Key == ConsoleKey.N)
            {
                StopGame();
            }
            else AskUserForRestart();
        }

        private void StopGame()
        {
            Console.SetCursorPosition(this.wall.LeftX / 2, this.wall.TopY + 2);
            Console.Write("Game Over!");
            Console.ReadKey(true);
            Environment.Exit(0);
        }

        private void ShowScore()
        {
            int leftX = this.wall.LeftX + 3;
            int topY = 1;

            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Your Score: {snake.Score}");
        }
    }
}