using System;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.GameObjects;
using Tic_Tac_Toe.Interfaces;
using Tic_Tac_Toe.Players;
using Index = Tic_Tac_Toe.GameObjects.Index;

namespace Tic_Tac_Toe.Core
{
    public class Engine
    {

        public void Run()
        {
            int select = ShowMenu();
            while (true)
            {
                Console.Clear();
                switch (select)
                {
                    case 1:
                        PlayGame(new ConsolePlayer(), new ConsolePlayer());
                        break;
                    case 2:
                        PlayGame(new ConsolePlayer(), new RandomPlayer());
                        break;
                    case 3:
                        PlayGame(new RandomPlayer(), new ConsolePlayer());
                        break;
                    case 4:
                        PlayGame(new ConsolePlayer(), new AiPlayer());
                        break;
                    case 5:
                        PlayGame(new AiPlayer(), new ConsolePlayer());
                        break;
                    case 6:
                        Simulate(new RandomPlayer(), new RandomPlayer(), 100);
                        break;
                    case 7:
                        Simulate(new AiPlayer(), new RandomPlayer(), 10);
                        break;
                    case 8:
                        Simulate(new RandomPlayer(), new AiPlayer(), 10);
                        break;
                    case 9:
                        Simulate(new AiPlayer(), new AiPlayer(), 10);
                        break;
                    case 0:
                        Console.WriteLine("Good Bye!");
                        Console.ReadLine();
                        Environment.Exit(0);
                        return;
                }

                Console.Write("Press [enter] to continue...");
                Console.ReadLine();
                select = ShowMenu();
            }
        }

        private int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("==== TicTacToe 1.0 ====");
            Console.WriteLine("1. Player vs Player");
            Console.WriteLine("2. Player vs Random");
            Console.WriteLine("3. Random vs Player");
            Console.WriteLine("4. Player vs AI");
            Console.WriteLine("5. AI vs Player");
            Console.WriteLine("6. Simulate Random vs Random");
            Console.WriteLine("7. Simulate AI vs Random");
            Console.WriteLine("8. Simulate Random vs AI");
            Console.WriteLine("9. Simulate AI vs AI");
            Console.WriteLine("0. Exit");

            int select = int.Parse(Console.ReadLine());

            return select;
        }

        private void Simulate(IPlayer player1, IPlayer player2, int count)
        {
            int x = 0, o = 0, draw = 0;
            int firstWinner = 0, secondWinner = 0;
            IPlayer first = player1;
            IPlayer second = player2;

            for (int i = 0; i < count; i++)
            {
                GameResult result = Play(first, second);

                switch (result.Winner)
                {
                    case Symbol.X when first == player1:
                        firstWinner++;
                        break;
                    case Symbol.O when first == player1:
                        secondWinner++;
                        break;
                    case Symbol.X when first == player2:
                        secondWinner++;
                        break;
                    case Symbol.O when first == player2:
                        firstWinner++;
                        break;
                }

                switch (result.Winner)
                {
                    case Symbol.X:
                        x++;
                        break;
                    case Symbol.O:
                        o++;
                        break;
                    case Symbol.None:
                        draw++;
                        break;
                }

                (first, second) = (second, first);
            }

            Console.WriteLine("Games played: " + count);
            Console.WriteLine("Games won by X: " + x);
            Console.WriteLine("Games won by O: " + o);
            Console.WriteLine("Draw games: " + draw);
            Console.WriteLine(player1.GetType().Name + " won games: " + firstWinner);
            Console.WriteLine(player2.GetType().Name + " won games: " + secondWinner);
        }

        private void PlayGame(IPlayer player1, IPlayer player2)
        {
            GameResult result = Play(player1, player2);

            Console.WriteLine("Game over!");
            if (result.Winner == Symbol.None)
            {
                Console.WriteLine("Winner: Draw");
            }
            else
            {
                Console.WriteLine("Winner: " + result.Winner);
            }

            Console.WriteLine(result.Board.ToString());
        }

        private GameResult Play(IPlayer player1, IPlayer player2)
        {
            IBoard board = new Board();
            IPlayer currPlayer = player1;
            Symbol symbol = Symbol.X;
            WinnerLogic wlogic = new WinnerLogic();

            while (!wlogic.IsGameOver(board))
            {
                Console.WriteLine(board.ToString());

                Index move = currPlayer.Play(board, symbol);
                board.PlaceSymbol(move, symbol);

                if (currPlayer == player1)
                {
                    currPlayer = player2;
                    symbol = Symbol.O;
                }
                else
                {
                    currPlayer = player1;
                    symbol = Symbol.X;
                }
                Console.Clear();
            }

            var winner = wlogic.GetWinner(board);

            return new GameResult(winner, board);
        }
    }
}