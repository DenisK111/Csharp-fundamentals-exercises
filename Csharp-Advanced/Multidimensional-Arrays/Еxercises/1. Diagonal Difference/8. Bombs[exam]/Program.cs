using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs_exam_
{
    class Program
    {
        /* You will be given a square matrix of integers, each integer separated by a single space, and each row on a new line. Then on the last line of input, you will receive indexes - coordinates to several cells separated by a single space, in the following format: row1,column1  row2,column2  row3,column3… 
On those cells there are bombs. You have to proceed with every bomb, one by one in the order they were given. When a bomb explodes deals damage equal to its integer value, to all the cells around it (in every direction and all diagonals). One bomb can't explode more than once and after it does, its value becomes 0. When a cell’s value reaches 0 or below, it dies. Dead cells can't explode.
You must print the count of all alive cells and their sum. Afterward, print the matrix with all of its cells (including the dead ones). 
Input
•	On the first line, you are given the integer N – the size of the square matrix.
•	The next N lines hold the values for every row – N numbers separated by a space.
•	On the last line, you will receive the coordinates of the cells with the bombs in the format described above.
Output
•	On the first line you need to print the count of all alive cells in the format: 
"Alive cells: {aliveCells}"
•	On the second line you need to print the sum of all alive cells in the format: 
"Sum: {sumOfCells}"
•	At the end print the matrix. The cells must be separated by a single space.
Constraints
•	The size of the matrix will be between [0…1000].
•	The bomb coordinates will always be in the matrix.
•	The bomb’s values will always be greater than 0.
•	The integers of the matrix will be in the range [1…10000]. 
*/
        static void Main(string[] args)
        {
            var matrix = ReadMatrix();
            

            string[] bombsInput = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Distinct().ToArray();
            List<Dictionary<int, int>> bombs = new List<Dictionary<int, int>>();

            foreach (var item in bombsInput)
            {
                int[] rowsAndCols = item.Split(",",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                bombs.Add(new Dictionary<int, int>() { [rowsAndCols[0]] = rowsAndCols[1] });
            }
            foreach (var item in bombs)
            {

                int bombRow = item.Keys.First();
                int bombCol = item.Values.First();
                int value = matrix[bombRow, bombCol];
                if (value<=0)
                {
                    value = 0;
                    continue;
                }
                if (matrix.GetLowerBound(0) < bombRow)
                {
                    matrix[bombRow - 1, bombCol] -= CheckIfAlive(matrix[bombRow - 1, bombCol]) ? value : 0;
                }

                if (matrix.GetUpperBound(0) > bombRow)
                {
                    matrix[bombRow + 1, bombCol] -= CheckIfAlive(matrix[bombRow + 1, bombCol]) ? value : 0;
                }

                if (matrix.GetUpperBound(1) > bombCol)
                {
                    matrix[bombRow, bombCol + 1] -= CheckIfAlive(matrix[bombRow, bombCol + 1]) ? value : 0;
                }

                if (matrix.GetLowerBound(1) < bombCol)
                {
                    matrix[bombRow, bombCol - 1] -= CheckIfAlive(matrix[bombRow, bombCol - 1]) ? value : 0;
                }

                if (matrix.GetLowerBound(0) < bombRow && matrix.GetUpperBound(1) > bombCol)
                {
                    matrix[bombRow - 1, bombCol + 1] -= CheckIfAlive(matrix[bombRow - 1, bombCol + 1]) ? value : 0;
                }

                if (matrix.GetUpperBound(0) > bombRow && matrix.GetUpperBound(1) > bombCol)
                {
                    matrix[bombRow + 1, bombCol + 1] -= CheckIfAlive(matrix[bombRow + 1, bombCol + 1]) ? value : 0;
                }

                if (matrix.GetUpperBound(0) > bombRow && matrix.GetLowerBound(1) < bombCol)
                {
                    matrix[bombRow + 1, bombCol - 1] -= CheckIfAlive(matrix[bombRow + 1, bombCol - 1]) ? value : 0;
                }
                if (matrix.GetLowerBound(0) < bombRow && matrix.GetLowerBound(1) < bombCol)
                {
                    matrix[bombRow - 1, bombCol - 1] -= CheckIfAlive(matrix[bombRow - 1, bombCol - 1]) ? value : 0;
                }

                matrix[bombRow, bombCol] = 0;
            }
            int totalSum = 0;
            int totalCount = 0;

            foreach (var item in matrix)
            {
                if (item>0)
                {
                    totalSum += item;
                    totalCount += 1;
                }
            }
            Console.WriteLine($"Alive cells: {totalCount}");
            Console.WriteLine($"Sum: {totalSum}");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }

        }

        static int[,] ReadMatrix()
        {
            int n = int.Parse(Console.ReadLine());

           
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];

            if (n == 0)
            {
                return matrix;
            }

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

        static bool CheckIfAlive(int num)
        {
            return num > 0;

        }
    }
}
