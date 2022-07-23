using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Connected_Areas_In_Matrix
{

    class ConnectedArea
    {
        public int Size { get; private set; }

        public void Add(int row, int col)
        {
            Size++;

        }




    }
    internal class Program
    {
        private static List<ConnectedArea> areas;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            areas = new List<ConnectedArea>();
            var matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col].ToString();
                }

            }
            var freespace = CheckForFreeSpaces(matrix);
            if (freespace.Item1)
            {
                GetAllPaths(matrix, freespace.Item2, freespace.Item3, new ConnectedArea(), 0);

            }
            Console.WriteLine(areas.Count);


        }

        private static void GetAllPaths(string[,] matrix, int row, int col, ConnectedArea area, int level)
        {
            if (row < 0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == "v" || matrix[row, col] == "d")
            {
                return;
            }

            area.Add(row, col);

            matrix[row, col] = "v";


            GetAllPaths(matrix, row + 1, col, area, level + 1);
            GetAllPaths(matrix, row - 1, col, area, level + 1);
            GetAllPaths(matrix, row, col + 1, area, level + 1);
            GetAllPaths(matrix, row, col - 1, area, level + 1);
            GetAllPaths(matrix, row - 1, col - 1, area, level + 1);
            GetAllPaths(matrix, row + 1, col + 1, area, level + 1);
            GetAllPaths(matrix, row + 1, col - 1, area, level + 1);
            GetAllPaths(matrix, row - 1, col + 1, area, level + 1);


            if (level == 0)
            {
                if (area.Size > 0)
                {
                    areas.Add(area);

                }

                Tuple<bool, int, int> returned = CheckForFreeSpaces(matrix);


                if (returned.Item1)
                {
                    GetAllPaths(matrix, returned.Item2, returned.Item3, new ConnectedArea(), 0);
                }


            }

        }

        private static Tuple<bool, int, int> CheckForFreeSpaces(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == "t")
                    {
                        return new Tuple<bool, int, int>(true, row, col);
                    }
                }
            }

            return new Tuple<bool, int, int>(false, 0, 0);
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write(matrix[row, col]);

                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}