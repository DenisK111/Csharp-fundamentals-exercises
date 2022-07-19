using System;
using System.Collections.Generic;
using System.Linq;

namespace NChooseKcount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            Dictionary<Tuple<int, int>, long> memoization = new Dictionary<Tuple<int, int>, long>();
            Console.WriteLine(Binom(n, k, memoization));
        }

        private static long Binom(int row, int col, Dictionary<Tuple<int, int>, long> memoizaton)
        {
            if (row <= 1)
            {
                return 1;
            }

            if (col == 0 || col == row)
            {
                return 1;
            }

            if (!memoizaton.Keys.Any(x => x.Item1 == row && x.Item2 == col))
            {

                memoizaton.Add(new Tuple<int, int>(row, col), Binom(row - 1, col, memoizaton) + Binom(row - 1, col - 1, memoizaton));
            }

            return memoizaton.First(x => x.Key.Item1 == row && x.Key.Item2 == col).Value;
        }
    }
}