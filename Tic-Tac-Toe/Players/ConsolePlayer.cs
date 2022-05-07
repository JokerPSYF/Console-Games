using System;
using System.Linq;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.Interfaces;
using Index = Tic_Tac_Toe.GameObjects.Index;

namespace Tic_Tac_Toe.Players
{
    public class ConsolePlayer : IPlayer
    {

        public Index Play(IBoard board, Symbol symbol)
        {
            //Console.Clear();
            Index position;

            while (true)
            {
                Console.Write($"{symbol} Please enter position (0,0): ");

                string input = Console.ReadLine();

                try
                {
                    position = new Index(input);
                }
                catch
                {
                    Console.WriteLine("Invalid position format!");
                    continue;
                }

                if (!board.GetEmptyPositions().Any(x => x.Equals(position)))
                {
                    Console.WriteLine("This position is not available!");
                    continue;
                }

                break;
            }

            return position;
        }
    }
}