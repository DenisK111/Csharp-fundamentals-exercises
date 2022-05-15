using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = ReadMatrix(n);
            char symbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row,col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        Environment.Exit(0);
                    }
                }
            }

            Console.WriteLine($"{symbol} does not occur in the matrix");
        }


        static char[,] ReadMatrix(int n)
        {

            // int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }
    }
}
