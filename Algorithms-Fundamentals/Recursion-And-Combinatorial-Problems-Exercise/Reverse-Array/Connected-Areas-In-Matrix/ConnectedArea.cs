using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Connected_Areas_In_Matrix

{
     class ConnectedArea :IComparable<ConnectedArea>
    {
        public ConnectedArea()
        {
            Row = int.MaxValue;
            Col = int.MaxValue;
        }
             

        public int Row { get; private set; } 
        public int Col { get; private set; }
        public int Size { get; private set; }

      public void Add(int row,int col)
        {
            Size++;
            if (row<=Row)
            {
                Row = row;
                if (col<Col)
                {
                    Col = col;
                }
            }
        }

        public int CompareTo( ConnectedArea other)
        {
            if (other.Size.CompareTo(this.Size) != 0)
            {
                return other.Size.CompareTo(this.Size);
            }

            else if (other.Row.CompareTo(this.Row) != 0)
            {
                return this.Row.CompareTo(other.Row);
            }

            else if (other.Col.CompareTo(this.Col) != 0)
            {
                return this.Col.CompareTo(other.Col);
            }

           return -1;
        }

        public override string ToString()
        {
            return "Area #{0} at " + $"({this.Row}, {this.Col}), size: {this.Size}";
        }
    }
}
