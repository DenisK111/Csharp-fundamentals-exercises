using System;
using System.Linq;

namespace Connecting_Cables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToArray();

            var positions = Enumerable.Range(1, numbers.Length).ToArray();

            var matrix = new int[numbers.Length + 1, positions.Length + 1];

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    
                    if (numbers[row-1] == positions[col-1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;

                    }

                    else
                    {
                        var max = Math.Max(matrix[row - 1, col], matrix[row, col - 1]);
                        matrix[row, col] = max;
                    }
                }
            }

            Console.WriteLine("Maximum pairs connected: " + matrix[positions.Length,positions.Length]);
        }
    }
}
