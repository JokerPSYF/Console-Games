using System;
using System.Linq;

namespace Tic_Tac_Toe.GameObjects
{
    public class Index
    {
        public Index(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
        
        public Index(string info)
        {
            int[] rowCol = info.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            this.Row = rowCol[0];
            this.Col = rowCol[1];
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public override bool Equals(object obj)
        {
            Index otherIndex = obj as Index;

            return this.Row == otherIndex.Row 
                   && this.Col == otherIndex.Col;
        }

        public override string ToString()
        {
            return $"{this.Row},{this.Col}";
        }
    }
}