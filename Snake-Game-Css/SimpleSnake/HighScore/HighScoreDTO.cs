using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace SimpleSnake.HighScore
{
    public class HighScoreDTO
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int Score { get; set; }
    }
}
