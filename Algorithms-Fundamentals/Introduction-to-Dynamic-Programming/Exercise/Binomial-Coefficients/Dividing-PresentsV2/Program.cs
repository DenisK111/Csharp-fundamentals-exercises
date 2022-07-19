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
            var allanSum = allSums.Keys.Where(x => x <= half).OrderBy( x => half -x).First();
            var bobSum = totalSum - allanSum;
            var diff = bobSum - allanSum;
            Console.WriteLine($"Difference: {diff}");
            Console.WriteLine($"Alan:{allanSum} Bob:{bobSum}");
            var allanPresents = FindSubset(allSums, allanSum);
            Console.WriteLine($"Alan takes: {string.Join(" ",allanPresents)}");
            Console.WriteLine("Bob takes the rest.");
        }

        private static List<int> FindSubset(Dictionary<int, int> sums, int target)
        {
            var subset = new List<int>();

            while (target>0)
            {
                subset.Add(sums[target]);
                target -= sums[target];
            }

            return subset;
        }

        private static Dictionary<int,int> GenerateSums(int[] presents)
        {
            var sums = new Dictionary<int, int> { [0] = 0};

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
