using System;

namespace Min_Edit_Distance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var replacementCost = int.Parse(Console.ReadLine());
            var insertCost = int.Parse(Console.ReadLine());
            var deleteCost = int.Parse(Console.ReadLine());

            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var matrix = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                matrix[r, 0] = deleteCost + matrix[r - 1, 0];
            }

            for (int c = 1; c < matrix.GetLength(1); c++)
            {
                matrix[0, c] = insertCost + matrix[0, c - 1];
            }

            for (int r = 1; r < matrix.GetLength(0); r++)
            {
                for (int c = 1; c < matrix.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c-1])
                    {
                        matrix[r, c] = matrix[r - 1, c - 1];
                    }

                    else
                    {
                        var replace = matrix[r - 1, c - 1] + replacementCost;
                        var insert = matrix[r, c - 1] + insertCost;
                        var delete = matrix[r - 1, c] + deleteCost;

                        matrix[r, c] = Math.Min(replace, Math.Min(insert, delete));
                    }
                    
                }
            }

            Console.WriteLine("Minimum edit distance: " + matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) -1]);
        }
    }
}
