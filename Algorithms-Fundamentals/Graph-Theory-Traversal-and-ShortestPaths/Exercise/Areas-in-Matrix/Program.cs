using System;
using System.Collections.Generic;
using System.Linq;

namespace Areas_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var inputRows = int.Parse(Console.ReadLine());
            var inputCols = int.Parse(Console.ReadLine());

            var matrix = new char[inputRows, inputCols];
            
            for (int row = 0; row < inputRows; row++)
            {
                var input = Console.ReadLine();

                for (int col = 0; col < inputCols; col++)
                {
                    matrix[row, col] = input[col];
                }

            }

            Dictionary<char, int> kvps = new Dictionary<char, int>();

           
            for (int row = 0; row < inputRows; row++)
            {
                for (int col = 0; col < inputCols; col++)
                {
                    var symbol = matrix[row, col];

                    if (symbol == 'v')
                    {
                        continue;
                    }

                    if (!kvps.ContainsKey(symbol))
                    {
                        kvps[symbol] = 0;
                    }

                    kvps[symbol]++;
                    TraverseMatrix(row, col,symbol,matrix);
                }
            }
            Console.WriteLine($"Areas: {kvps.Values.Sum()}");
            foreach (var kvp in kvps.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }

                
        }

        private static void TraverseMatrix(int row, int col,char symbol,char[,] matrix)
        {
           

            if (row<0 || row >= matrix.GetLength(0) || col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (symbol != matrix[row, col])
            {
                return;
            }

            matrix[row, col] = 'v';

            TraverseMatrix(row-1,col,symbol,matrix);
            TraverseMatrix(row+1,col,symbol,matrix);
            TraverseMatrix(row,col-1,symbol,matrix);
            TraverseMatrix(row,col+1,symbol,matrix);

        }
    }
}
