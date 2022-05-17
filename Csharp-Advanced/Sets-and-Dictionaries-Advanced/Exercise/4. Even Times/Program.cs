using System;
using System.Collections.Generic;

namespace _4._Even_Times
{
    class Program
    {
        /*Create a program that prints a number from a collection, which appears an even number of times in it. On the first line, you will be given n – the count of integers you will receive. On the next n lines, you will be receiving the numbers. It is guaranteed that only one of them appears an even number of times. Your task is to find that number and print it in the end. */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var numSetOfOdd = new HashSet<int>();
            var numSetOfEven = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (numSetOfOdd.Contains(number))
                {
                    numSetOfEven.Add(number);
                    numSetOfOdd.Remove(number);
                }

                else
                {
                    numSetOfOdd.Add(number);
                    numSetOfEven.Remove(number);
                }
            }

            foreach (var item in numSetOfEven)
            {
                Console.WriteLine(item);
            }

        }
    }
}
