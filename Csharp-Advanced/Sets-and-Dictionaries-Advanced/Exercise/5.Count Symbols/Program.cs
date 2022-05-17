using System;
using System.Collections.Generic;

namespace _5.Count_Symbols
{
    class Program
    {

        /* Create a program that reads some text from the console and counts the occurrences of each character in it. Print the results in alphabetical (lexicographical) order. */
        static void Main(string[] args)
        {
            SortedDictionary<char, int> charCount = new SortedDictionary<char, int>();

            string input = Console.ReadLine();

            foreach (var item in input)
            {
                if (!charCount.ContainsKey(item))
                {
                    charCount[item] = 0;
                }

                charCount[item] += 1;
            }

            foreach (var item in charCount)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
