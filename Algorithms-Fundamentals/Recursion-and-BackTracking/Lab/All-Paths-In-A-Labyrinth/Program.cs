using System;
using System.Collections.Generic;

namespace All_Paths_In_A_Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            
            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col].ToString();
                }

            }

            PrintAllPaths(matrix, 0, 0, new List<string>(), string.Empty);
        }

        private static void PrintAllPaths(string[,] matrix, int row, int col, List<string> directions, string direction)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row,col] == "v" || matrix[row,col] == "*")
            {
                return;
            }

            directions.Add(direction);

            if (matrix[row,col] == "e")
            {
                Console.WriteLine(String.Join("",directions));
                directions.RemoveAt(directions.Count - 1);
                return;
            }

            matrix[row, col] = "v";


            PrintAllPaths(matrix, row + 1, col, directions, "D");
            PrintAllPaths(matrix, row - 1, col, directions, "U");
            PrintAllPaths(matrix, row, col+1, directions, "R");
            PrintAllPaths(matrix, row, col-1, directions, "L");

            matrix[row, col] = "-";
            directions.RemoveAt(directions.Count - 1);

        }
    }
}
