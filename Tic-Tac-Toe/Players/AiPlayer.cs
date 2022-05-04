using System;
using System.Collections.Generic;
using System.Linq;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.GameObjects;
using Tic_Tac_Toe.Interfaces;
using Index = Tic_Tac_Toe.GameObjects.Index;

namespace Tic_Tac_Toe.Players
{
    public class AiPlayer : IPlayer
    {
        public AiPlayer()
        {
            this.WlLogic = new WinnerLogic();
        }

        public WinnerLogic WlLogic { get; set; }

        public Index Play(IBoard board, Symbol symbol)
        {
            Index bestMove = null;
            int bestMoveValue = -1000;
            List<Index> moves = board.GetEmptyPositions().ToList();

            foreach (var move in moves)
            {
                board.PlaceSymbol(move, symbol);
                int value = MiniMax(board, symbol, symbol == Symbol.X ? Symbol.O : Symbol.X);
                board.PlaceSymbol(move, Symbol.None);
                if (value > bestMoveValue)
                {
                    bestMove = move;
                    bestMoveValue = value;
                }

            }

            return null;
        }

        private int MiniMax(IBoard board, Symbol player, Symbol currPlayer)
        {
            if (this.WlLogic.IsGameOver(board))
            {
                Symbol winner = this.WlLogic.GetWinner(board);

                if (winner == player) return 1;
                else if (winner == Symbol.None) return 0;
                else return -1;
            }

            int bestValue = player == currPlayer ? -100 : 100;
            List<Index> options = board.GetEmptyPositions().ToList();

            foreach (Index option in options)
            {
                board.PlaceSymbol(option, currPlayer);

                int value = MiniMax(board, player, currPlayer == Symbol.O ? Symbol.X : Symbol.O);

                board.PlaceSymbol(option, Symbol.None);

                bestValue = currPlayer == player ? Math.Max(bestValue, value) : Math.Min(bestValue, value);
            }

            return bestValue;
        }
    }
}