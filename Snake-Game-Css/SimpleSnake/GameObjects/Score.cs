using Newtonsoft.Json;
using SimpleSnake.HighScore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace SimpleSnake.GameObjects
{
    public class Score
    {
        private Snake snake;
        private Wall wall;

        private int leftX;
        private int topY;
        private string jsonPath =
           Path.GetFullPath(Path.Combine(Environment.CurrentDirectory
            .ToString(), @"..\..\..\HighScore") + @"\high-score.json");

        public string PlayerName { get; private set; }
        public int PlayerHighScore { get; private set; }


        public Score(Snake snake, Wall wall)
        {
            this.snake = snake;
            this.wall = wall;
            Desirialize();

            leftX = wall.LeftX + 3;
            topY = 1;
        }

        public void ShowScore()
        {
            Console.SetCursorPosition(leftX, topY);
            Console.Write($"Best Player: {this.PlayerName} High Score: {this.PlayerHighScore}");


            Console.SetCursorPosition(leftX, topY + 2);
            Console.Write($"Your Score: {snake.Score}");
        }

        public bool IsNewHighScore(int newScore) => newScore > this.PlayerHighScore;

        public void RegisterNewHighScore()
        {
            Console.SetCursorPosition(leftX, topY + 4);
            Console.Write($"Congratulation, that's new high score!!! Write your name:");
            string name = Console.ReadLine();

            HighScoreDTO newScore = new HighScoreDTO()
            {
                Name = name.Trim(),
                Score = snake.Score
            };

            string json = JsonConvert.SerializeObject(newScore, Formatting.Indented);
            File.WriteAllText(jsonPath, json.TrimEnd());
        }

        private void Desirialize()
        {
            var dto = JsonConvert.DeserializeObject<HighScoreDTO>(File.ReadAllText(jsonPath));

            this.PlayerHighScore = (int)dto.Score;
            this.PlayerName = dto.Name;
        }
    }
}
