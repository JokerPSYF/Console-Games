using System;
using System.Linq;

namespace Tic_Tac_Toe.GameObjects
{
    public class Index
    {
        private int row;
        private int col;

        public Index(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
        
        public Index(string info)
        {
            int[] rowCol = info.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            this.row = rowCol[0];
            this.col = rowCol[1];
        }

        public override bool Equals(object obj)
        {
            Index otherIndex = obj as Index;

            return this.row == otherIndex.row 
                   && this.col == otherIndex.col;
        }

        public override string ToString()
        {
            return $"{this.row},{this.col}";
        }
    }
}