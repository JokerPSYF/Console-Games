using System;
using System.Text;
using System.Threading;
using System.Media;
using Microsoft.Win32;

namespace HelicopterPericopter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.CursorVisible = false;

            if (OperatingSystem.IsWindows())
            {
                // player = music player
                var player = new SoundPlayer();
                player.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Helikopter.wav";
                player.Load();
                player.PlayLooping();
            }

            int count = 0;
            while (!Console.KeyAvailable)
            {

                Thread.Sleep(100);
                Console.Clear();

                if (count % 2 == 0)
                {
                    count++;
                    Console.WriteLine(@" ===============^ ==    --    -");
                    Console.WriteLine(@"                ^              ");
                    Console.WriteLine(@" ''|        /--|||----------\");
                    Console.WriteLine(@"==<0>=======|      [ 0 ][ 0 ]\");
                    Console.WriteLine(@"   |/       \     ===   W  ===\");
                    Console.WriteLine(@"             \________________/");
                    Console.WriteLine(@"                ||       ||    ");
                    Console.WriteLine(@"             /----------------\");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    count++;
                    Console.WriteLine(@"  -    --    == ^================");
                    Console.WriteLine(@"                ^              ");
                    Console.WriteLine(@" ''|/       /--|||----------\");
                    Console.WriteLine(@"==<0>=======|      [ 0 ][ 0 ]\");
                    Console.WriteLine(@"   |        \     ===   W  ===\");
                    Console.WriteLine(@"             \________________/");
                    Console.WriteLine(@"                ||       ||    ");
                    Console.WriteLine(@"             /----------------\");
                    Console.WriteLine();
                    Console.WriteLine();
                }
            }
        }
    }
}
