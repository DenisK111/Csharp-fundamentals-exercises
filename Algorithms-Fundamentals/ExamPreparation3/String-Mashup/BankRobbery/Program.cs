using System;
using System.Collections.Generic;
using System.Linq;

namespace Dividing_PresentsV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var presents = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var allSums = GenerateSums(presents);

            var totalSum = presents.Sum();
            var half = totalSum / 2;
            
            var joshPresents = FindSubset(allSums, half).OrderBy(x => x);
            var prakashPresents = presents.Except(joshPresents).OrderBy(x => x).ToArray();
            Console.WriteLine(string.Join(" ", joshPresents));
            Console.WriteLine(string.Join(" ", prakashPresents));
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target > 0)
            {
                subset.Add(sums[target]);
                target -= sums[target];
            }

            return subset;
        }

        private static Dictionary<int, int> GenerateSums(int[] presents)
        {
            var sums = new Dictionary<int, int> { [0] = 0 };

            foreach (var present in presents)
            {
                var currentSums = sums.Keys.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = present + sum;

                    if (sums.ContainsKey(newSum))
                    {
                        continue;
                    }

                    sums.Add(newSum, present);
                }
            }

            return sums;
        }
    }
}