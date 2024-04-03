using System;
using System.IO;

namespace SimpleSnake.Sounds
{
    public static class Song
    {
        public static string techno = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory
              .ToString(), @"..\..\..\Sounds\Songs") + @"\Snake-Game-Music.wav");

        public static string classic = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory
             .ToString(), @"..\..\..\Sounds\Songs") + @"\Snake3.wav");
    }
}
