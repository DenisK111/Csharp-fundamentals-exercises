using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2._Square_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            var matrix = ReadMatrix(n, m);

            const int REQUIREDROWS = 2;
            const int REQUIREDCOLS = 2;

            int numberFound = 0;

            for (int row = 0; row <= matrix.GetLength(0) - REQUIREDROWS; row++)
            {
                for (int col = 0; col <= matrix.GetLength(1) - REQUIREDCOLS; col++)
                {
                    char[] check = new char[REQUIREDCOLS * REQUIREDROWS];
                    
                    for (int currRow = row, checkIndex = 0; currRow < row + REQUIREDROWS; currRow++)
                    {
                        for (int currCol = col; currCol < col + REQUIREDCOLS; currCol++, checkIndex++)
                        {
                            check[checkIndex] = matrix[currRow, currCol];
                           
                        }
                    }

                    if (check.Length == 0)
                    {
                        continue;
                    }

                    if (check.Distinct().Count() == 1)
                    {
                        numberFound++;
                    }


                }
            }

            Console.WriteLine(numberFound);


        }

        static char[,] ReadMatrix(int n, int m)
        {

            int rows = n;
            int cols = m;
            char[,] matrix = new char[rows, cols];

            if (rows == 0 || cols == 0)
            {
                return matrix;
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }

        


    }

    
        
    
}
