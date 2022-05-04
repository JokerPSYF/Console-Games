using System;
using System.Collections.Generic;
using System.Linq;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.Interfaces;
using Index = Tic_Tac_Toe.GameObjects.Index;

namespace Tic_Tac_Toe.Players
{
    public class RandomPlayer :IPlayer
    {
        private Random rand;

        public RandomPlayer()
        {
            this.rand = new Random();
        }

        public Index Play(IBoard board, Symbol symbol)
        {
            List <Index> emptyPos = board.GetEmptyPositions().ToList();

            return emptyPos[rand.Next(0, emptyPos.Count)];
        }
    }
}