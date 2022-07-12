using System;
using System.Collections.Generic;

namespace _8_Queens_Problem
{
    internal class Program
    {
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedCols = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonal = new HashSet<int>();
        static HashSet<int> attackedRightDiagonal = new HashSet<int>();
        static void Main(string[] args)
        {
            var matrix = new bool[8,8];

            Print8QueensSolution(matrix, 0);
        }

        private static void Print8QueensSolution(bool[,] matrix, int row)
        {
            if (row == matrix.GetLength(0))
            {
                PrintMatrix(matrix);
                return;
            }
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                if ((QueenCanBePut(row, col)))
                {
                    matrix[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonal.Add(col - row);
                    attackedRightDiagonal.Add(row + col);
                    Print8QueensSolution(matrix, row + 1);
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonal.Remove(col - row);
                    attackedRightDiagonal.Remove(row + col);
                    matrix[row, col] = false;
                }
            }
                      




        }

        private static bool QueenCanBePut(int row, int col)
        {
            return //!attackedRows.Contains(row) &&
                   !attackedCols.Contains(col) &&
                   !attackedLeftDiagonal.Contains(col - row) &&
                   !attackedRightDiagonal.Contains(row + col);


        }

        private static void PrintMatrix(bool[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row,col])
                    {
                        Console.Write("* ");
                    }

                    else
                    {
                        Console.Write("- ");
                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
