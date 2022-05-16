using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrix = ReadMatrix(input[0],input[1]);

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                else if (command[0] != "swap" || command.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int row1 = int.Parse(command[1]);
                int col1 = int.Parse(command[2]);
                int row2 = int.Parse(command[3]);
                int col2 = int.Parse(command[4]);

                if (row1 < 0 || col1<0 || row2<0 || col2<0 || row1>matrix.GetUpperBound(0) || row2 > matrix.GetUpperBound(0) || col1 > matrix.GetUpperBound(1) || col2 > matrix.GetUpperBound(1))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                else
                {
                    string temp = matrix[row1, col1];
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = temp;


                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write($"{matrix[row, col]} ");
                        }
                        Console.WriteLine();
                    }


                }

            }


        }


        static string[,] ReadMatrix(int n, int m)
        {

            int rows = n;
            int cols = m;
            string[,] matrix = new string[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            return matrix;
        }
    }
}
