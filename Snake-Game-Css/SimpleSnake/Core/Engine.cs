using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.HighScore;
using SimpleSnake.Sounds;

namespace SimpleSnake.Core
{
    public class Engine
    {
        private Wall wall;
        private Snake snake;
        private Point[] pointsOfDirections;
        private readonly Score score;
        private double sleepTime;
        private Direction direction;
        private int leftX;
        private int topY;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            this.score = new Score(snake, wall);
            sleepTime = 100;
            pointsOfDirections = new Point[4];
            leftX = this.wall.LeftX + 3;
            topY = 0;
        }

        private void CreateDirections()
        {
            //right
            this.pointsOfDirections[0] = new Point(1, 0);
            //left
            this.pointsOfDirections[1] = new Point(-1, 0);
            //down
            this.pointsOfDirections[2] = new Point(0, 1);
            //up
            this.pointsOfDirections[3] = new Point(0, -1);
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                score.ShowScore();
                if (Console.KeyAvailable)
                {
                    GetNextDirections();
                }

                bool isMoving = snake.IsMoving(this.pointsOfDirections[(int)direction]);

                if (!isMoving)
                {
                    if (score.IsNewHighScore(snake.Score))
                    {
                        score.RegisterNewHighScore();
                    }
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
                    if (direction != Direction.Up)
                    {
                        direction = Direction.Down;
                    }
                    break;
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            MusicPlayer.Instance.Stop();
            Console.SetCursorPosition(leftX, topY + 7);
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
            Console.SetCursorPosition(leftX, topY + 9);
            Console.Write("Game Over!");
            Console.ReadKey(true);
            Console.SetCursorPosition(this.wall.LeftX / 2, this.wall.TopY + 1);
            Environment.Exit(0);
        }

        public int GetScore() => snake.Score;

    }
}