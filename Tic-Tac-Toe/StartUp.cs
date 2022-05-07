using System;
using System.Text;
using Tic_Tac_Toe.Core;

namespace Tic_Tac_Toe
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.Title = "TicTacToe 1.0";
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello World! \u2588");

            Engine engine = new Engine();
            engine.Run();
        }
    }
}
