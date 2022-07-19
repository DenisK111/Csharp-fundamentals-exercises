using System;
using System.Collections.Generic;
using System.Linq;

namespace Sum_Limited_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                 .Split()
                 .Select(int.Parse)
                 .ToArray();
            var target = int.Parse(Console.ReadLine());

            var allSum = GenerateAllSum(numbers, target);

            Console.WriteLine(allSum);
        }

        private static int GenerateAllSum(int[] numbers, int target)
        {
            var totalSums = 0;

            var sums = new HashSet<int> { 0 }; 

            foreach (var number in numbers)
            {
                var currentSums = sums.ToArray();

                foreach (var sum in currentSums)
                {
                    var newSum = number + sum;

                    if (newSum == target)
                    {
                        totalSums++;
                    }
                                    

                    sums.Add(newSum);
                    
                }

                sums.UnionWith(currentSums);
            }

            return totalSums;

            
        }
    }
}
