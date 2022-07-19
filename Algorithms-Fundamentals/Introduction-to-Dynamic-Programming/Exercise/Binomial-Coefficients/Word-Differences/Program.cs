using System;
using System.Linq;

namespace Word_Differences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var matrix = new int[str1.Length + 1,str2.Length+1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = 1 + matrix[row - 1,0];

            }

            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0,col] = 1 + matrix[0,col-1];

            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (str1[row-1] == str2[col-1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }

                    else
                    {
                        var min = Math.Min(matrix[row - 1, col], matrix[row, col - 1]);
                        matrix[row, col] = min + 1;

                    }

                }
            }

            Console.WriteLine($"Deletions and Insertions: "  + matrix[matrix.GetLength(0) - 1,matrix.GetLength(1)-1]);
            

            
        }
    }
}
