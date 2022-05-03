using System.Collections;
using System.Collections.Generic;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.GameObjects;

namespace Tic_Tac_Toe.Interfaces
{
    public interface IBoard
    {
        bool IsFull();

        void PlaceSymbol(Index index, Symbol symbol);

        IEnumerable<Index> GetEmptyPositions();

        Symbol GetRowSymbol(int row);

        Symbol GetColSymbol(int col);

        Symbol GetDiagonalTopLeftSymbol();

        Symbol GetDiagonalTopRightSymbol();
    }
}