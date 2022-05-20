using System;
using System.Linq;
using System.Collections.Generic;

namespace _4.Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> range = new List<int>();
            int smaller = Math.Min(input[0], input[1]);
            int larger = Math.Max(input[0], input[1]);
            IEnumerable<int> rangeToAdd = Enumerable.Range(smaller, larger - smaller + 1);
            range.AddRange(rangeToAdd);
            string command = Console.ReadLine();
            Predicate<int> checkIfEvenOrOdd = checkEvenOrOdd(command);
            Console.WriteLine(String.Join(" ",range.FindAll(x=> checkIfEvenOrOdd(x))));
        }

        static Predicate<int> checkEvenOrOdd(string command)
        {
            if (command == "even")
            {
                return x => x % 2 == 0;
            }
            else
            {
                return x => x % 2 != 0;
            }

        }
    }
}
