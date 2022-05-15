using System;
using System.Linq;

namespace _7.Pascal_Traiangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[n][];

            jaggedArray[0] = new long[] { 1 };
            for (int rows = 1; rows < n; rows++)
            {
                jaggedArray[rows] = new long[rows + 1];

                for (int i = 0; i < jaggedArray[rows].Length; i++)
                {
                    if (i > 0 && i < jaggedArray[rows - 1].Length)
                    {

                        jaggedArray[rows][i] = jaggedArray[rows - 1][i] + jaggedArray[rows - 1][i - 1];
                    }

                    else
                    {
                        jaggedArray[rows][i] = 1;
                    }

                }
            }

            PrintJaggedArray(jaggedArray);





        }

        static void PrintJaggedArray(long [][] jaggedArray)
        {

            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}