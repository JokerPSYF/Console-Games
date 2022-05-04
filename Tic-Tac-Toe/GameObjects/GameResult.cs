using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.Interfaces;

namespace Tic_Tac_Toe.GameObjects
{
    public class GameResult
    {
        public GameResult(Symbol winner, IBoard board)
        {
            Winner = winner;
            Board = board;
        }

        public Symbol Winner { get; }
        public IBoard Board { get; }
    }
}