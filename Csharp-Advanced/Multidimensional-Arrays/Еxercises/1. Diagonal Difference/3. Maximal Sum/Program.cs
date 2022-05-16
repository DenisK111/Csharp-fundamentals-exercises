using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var matrix = ReadMatrix(input[0], input[1]);

            const int REQUIREDROWS = 3;
            const int REQUIREDCOLS = 3;

            int maxSum = int.MinValue;
            int[,] currMatrix = new int[REQUIREDROWS, REQUIREDCOLS];
            int[,] bestMatrix = new int[REQUIREDROWS, REQUIREDCOLS];

            for (int row = 0; row <= matrix.GetLength(0) - REQUIREDROWS; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - REQUIREDCOLS; col++)
                {

                    int sum = 0;
                    currMatrix = new int[REQUIREDROWS, REQUIREDCOLS];
                    for (int currRow = row,currMatrixRow = 0; currRow < row + REQUIREDROWS; currRow++, currMatrixRow++)
                    {
                        for (int currCol = col,currMatrixCol = 0; currCol < col + REQUIREDCOLS; currCol++,currMatrixCol++)
                        {
                            sum += matrix[currRow,currCol];
                            currMatrix[currMatrixRow, currMatrixCol] = matrix[currRow, currCol];



                        }
                    }


                    if (sum > maxSum)
                    {
                        maxSum = sum;

                        bestMatrix = (int[,])currMatrix.Clone();

                    }

                  
                    


                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for (int row = 0; row < bestMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < bestMatrix.GetLength(1); col++)
                {
                    Console.Write($"{bestMatrix[row, col]} ");
                }

                Console.WriteLine();
            }

            


        }

        static int[,] ReadMatrix(int n,int m)
        {

            int rows = n;
            int cols = m;
            int[,] matrix = new int[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }
    }
}
