using System;
using System.Collections.Generic;
using System.Linq;

namespace TimeLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var array2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var lcs = new int[array1.Length + 1, array2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (array1[r - 1] == array2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }

                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r, c - 1], lcs[r - 1, c]);
                    }
                }
            }

            /// RECOVER THE LCS
            var sequence = new List<int>();
            var row = array1.Length;
            var col = array2.Length;
            while (row > 0 && col > 0)
            {
                if (array1[row - 1] == array2[col - 1] &&
                    lcs[row, col] == lcs[row - 1, col - 1] + 1)
                {
                    sequence.Add(array1[row - 1]);
                    row--;
                    col--;
                }

                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }

                else
                {
                    col--;
                }
            }

            sequence.Reverse();
            Console.WriteLine(String.Join(" ", sequence));
            Console.WriteLine(lcs[array1.Length, array2.Length]);
        }
    }
}
