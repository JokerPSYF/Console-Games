using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tic_Tac_Toe.Enum;
using Tic_Tac_Toe.Interfaces;

namespace Tic_Tac_Toe.GameObjects
{
    public class Board : IBoard
    {
        private Symbol[,] board;

        public Board() : this(3, 3)
        {
            
        }

        public Board(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            board = new Symbol[rows, cols];
        }

        public int Rows { get; set; }
        public int Cols { get; set; }
        public Symbol[,] BoardState => board;

        public bool IsFull()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == Symbol.None)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void PlaceSymbol(Index index, Symbol symbol)
        {
            if (index.Row < 0 || index.Row >= this.Rows || index.Col < 0 || index.Col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Index is out of range.");
            }

            this.board[index.Row, index.Col] = symbol;
        }

        public IEnumerable<Index> GetEmptyPositions()
        {
            List<Index> emptyPos = new List<Index>();

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Cols; col++)
                {
                    if (board[row, col] == Symbol.None)
                    {
                        emptyPos.Add(new Index(row, col));
                    }
                }
            }

            return emptyPos;
        }

        public Symbol GetRowSymbol(int row)
        {
            Symbol symbol = board[row, 0];

            if (symbol == Symbol.None) return symbol;

            for (int col = 1; col < Cols; col++)
            {
                if (board[row, col] != symbol)
                {
                    return Symbol.None;
                }   
            }

            return symbol;
        }

        public Symbol GetColSymbol(int col)
        {
            Symbol symbol = board[0, col];

            if (symbol == Symbol.None) return symbol;

            for (int row = 1; row < Rows; row++)
            {
                if (board[row, col] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTopLeftSymbol()
        {
            Symbol symbol = board[0, 0];

            if (symbol == Symbol.None) return symbol;

            for (int i = 1; i < Rows; i++)
            {
                if (board[i, i] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public Symbol GetDiagonalTopRightSymbol()
        {
            Symbol symbol = board[0, this.Cols-1];

            if (symbol == Symbol.None) return symbol;

            for (int i = 1; i < Rows; i++)
            {
                if (board[i, this.Cols - i - 1] != symbol)
                {
                    return Symbol.None;
                }
            }

            return symbol;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (board[row, col] == Symbol.None)
                    {
                        sb.Append('\u2588');
                    }
                    else
                    {
                        sb.Append(board[row, col]);
                    }
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}