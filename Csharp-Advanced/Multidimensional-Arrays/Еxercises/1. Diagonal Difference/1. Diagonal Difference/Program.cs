using System;
using System.Linq;
using System.Collections.Generic;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = ReadMatrix(n);

            int sum1 = 0;
            int sum2 = 0;

            for (int row = 0, col = 0,endcol = matrix.GetLength(1) -1; row < matrix.GetLength(0); row++,col++,endcol--)
            {
                sum1 += matrix[row, col];
                sum2 += matrix[row, endcol];
            }

            Console.WriteLine(Math.Abs(sum1-sum2));
            

        }

        static int[,] ReadMatrix(int n)
        {
                       
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }

    }
}
