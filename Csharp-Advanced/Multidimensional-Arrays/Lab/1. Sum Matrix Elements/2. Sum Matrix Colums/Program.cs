using System;
using System.Linq;

namespace _2._Sum_Matrix_Colums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int sum = 0;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    sum += matrix[row,col];
                }
                Console.WriteLine(sum);
            }
        }

        static int[,] ReadMatrix()
        {

            int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];
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
