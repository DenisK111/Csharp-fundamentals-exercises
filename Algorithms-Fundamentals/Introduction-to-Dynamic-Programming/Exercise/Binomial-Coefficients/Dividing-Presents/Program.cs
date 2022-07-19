using System;
using System.Collections.Generic;
using System.Linq;

namespace Dividing_Presents
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            input = input.OrderByDescending(x => x).ToArray();
            var alan = new List<int>();
            var bob = new List<int>();

            foreach (var num in input)
            {
                if (alan.Sum()>bob.Sum())
                {
                    bob.Add(num);
                    
                }

                else
                {
                    alan.Add(num);
                }
            }

            var alanSum = alan.Sum();
            var bobSum = bob.Sum();

            Console.WriteLine($"Difference: {Math.Abs(alanSum-bobSum)}");
            Console.WriteLine($"Alan:{alanSum} Bob:{bobSum}");
            Console.WriteLine($"Alan takes: {string.Join(" ",alan)}");
            Console.WriteLine("Bob takes the rest.");


        }
    }
}
