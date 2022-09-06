using System;
using SimpleSnake.Core;
using SimpleSnake.GameObjects;
using SimpleSnake.Sounds;


namespace SimpleSnake
{
    using System.IO;
    using Utilities;


    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(50, 25);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(wall, snake);
            //That's the path of the song and not literally the song
            string song = Song.classic;

            MusicPlayer sound = MusicPlayer.Instance;

            sound.Play(song);

            engine.Run();
        }
    }
}
