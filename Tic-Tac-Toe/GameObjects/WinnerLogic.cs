using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.Interfaces;

namespace Tic_Tac_Toe.GameObjects
{
    public class WinnerLogic
    {
        public bool IsGameOver(IBoard board)
        {
            for (int row = 0; row < board.Rows; row++)
            {
                if (board.GetRowSymbol(row) != Symbol.None)
                {
                    return true;
                }
            }
            
            for (int col = 0; col < board.Cols; col++)
            {
                if (board.GetColSymbol(col) != Symbol.None)
                {
                    return true;
                }
            }

            if (board.GetDiagonalTopLeftSymbol() != Symbol.None)
            {
                return true;
            }

            if (board.GetDiagonalTopRightSymbol() != Symbol.None)
            {
                return true;
            }


            return board.IsFull();
        }

        public Symbol GetWinner(IBoard board)
        {
            Symbol winner;

            for (int row = 0; row < board.Rows; row++)
            {
                winner = board.GetRowSymbol(row);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            for (int col = 0; col < board.Cols; col++)
            {
                winner = board.GetColSymbol(col);

                if (winner != Symbol.None)
                {
                    return winner;
                }
            }

            winner = board.GetDiagonalTopLeftSymbol();

            if (winner != Symbol.None)
            {
                return winner;
            }

            winner = board.GetDiagonalTopRightSymbol();

            if (winner != Symbol.None)
            {
                return winner;
            }

            return Symbol.None;
        }
    }
}