using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();
            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);

        }

        static int[,] ReadMatrix()
        {

            int[] rowsCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int rows = rowsCols[0];
            int cols = rowsCols[1];
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }
    }
}
