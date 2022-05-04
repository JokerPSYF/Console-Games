using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.GameObjects;

namespace Tic_Tac_Toe.Interfaces
{
    public interface IPlayer
    {
        Index Play(IBoard board, Symbol symbol);
    }
}