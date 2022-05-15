using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = ReadMatrix(n);
            int sum = 0;
            for (int col = 0, row=0; col < n; col++,row++)
            {
                sum += matrix[row, col];
            }

            Console.WriteLine(sum);

        }

        static int[,] ReadMatrix(int n)
        {

            // int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

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
