using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Move_Down_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int irow = 0; irow < matrix.GetLength(0); irow++)
            {
                var input = Console.ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

                for (int icol = 0; icol < matrix.GetLength(1); icol++)
                {
                    matrix[irow, icol] = input[icol];
                }
            }

            var sumMatrix = new int[rows, cols];
            sumMatrix[0, 0] = matrix[0, 0];

            for (int c = 1; c < sumMatrix.GetLength(1); c++)
            {
                sumMatrix[0, c] = sumMatrix[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < sumMatrix.GetLength(0); r++)
            {
                sumMatrix[r,0] = sumMatrix[r-1, 0] + matrix[r,0];
            }
            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    var upper = sumMatrix[r - 1, c];
                    var left = sumMatrix[r, c - 1];

                    var result = Math.Max(upper, left);

                    sumMatrix[r, c] = result + matrix[r, c];
                }
            }

            var stack = new Stack<string> ();

            var row = rows - 1;
            var col = cols - 1;
            stack.Push($"[{row}, {col}]");
            while (row > 0 && col>0)
            {
                var upper = sumMatrix[row - 1, col];
                var left = sumMatrix[row, col -1];

                if (upper > left)
                {
                    row--;
                }

                else
                {
                    col--;
                }

                stack.Push($"[{row}, {col}]");
            }

            while (row == 0 && col != 0)
            {
                col--;
                stack.Push($"[{row}, {col}]");

            }

            while (col == 0 && row!= 0)
            {
                row--;
                stack.Push($"[{row}, {col}]");
            }

            Console.WriteLine(String.Join(" ",stack));
        }
    }
}
