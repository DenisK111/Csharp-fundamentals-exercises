using System;
using System.Linq;

namespace _5._Square_with_Maximum_Sum
{
    class Program
    {
        /* Create a program that reads a matrix from the console. Then find the biggest sum of the 2x2 submatrix and print it to the console.
On the first line, you will get matrix sizes in format rows, columns.
In the lines of One next row, you will get elements for each column separated with a comma.
Print the biggest top-left square, which you find, and the sum of its elements.
*/
        static void Main(string[] args)
        {
            int[,] matrix = ReadMatrix();
            int[,] bestMatrix = new int[2, 2];
            bestMatrix[0, 0] = int.MinValue;
            bestMatrix[0, 1] = int.MinValue;
            bestMatrix[1, 0] = int.MinValue;
            bestMatrix[1, 1] = int.MinValue;
            int bestMatrixSum = int.MinValue;

            
            for (int r = 0; r < matrix.GetLength(0) - 1; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 1; c++)
                {
                    int[,] currMatrix = new int[2, 2];
                    currMatrix[0, 0] = matrix[r, c];
                    currMatrix[0, 1] = matrix[r, c + 1];
                    currMatrix[1, 0] = matrix[r + 1, c];
                    currMatrix[1, 1] = matrix[r + 1, c + 1];

                    if (currMatrix[0, 0] + currMatrix[0, 1] + currMatrix[1, 0]+ currMatrix[1, 0] > bestMatrixSum)
                    {
                        bestMatrixSum = currMatrix[0, 0] + currMatrix[0, 1] + currMatrix[1, 0] + currMatrix[1, 0];
                        bestMatrix[0, 0] = currMatrix[0, 0];
                        bestMatrix[0, 1] = currMatrix[0, 1];
                        bestMatrix[1, 0] = currMatrix[1, 0];
                        bestMatrix[1, 1] = currMatrix[1, 1];
                    }


                }
            }

            for (int row = 0; row < bestMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bestMatrix.GetLength(1); col++)
                {
                    Console.Write(bestMatrix[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine(bestMatrixSum);

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
