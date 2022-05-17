using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_same_value_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var countOfNums = new Dictionary<double, int>();

            foreach (var item in input)
            {
                if (!countOfNums.ContainsKey(item))
                {
                    countOfNums[item] = 0;
                }
                countOfNums[item] += 1;

            }

            foreach (var item in countOfNums)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            };
        }
    }
}
