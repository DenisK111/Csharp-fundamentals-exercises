using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            input = input.OrderByDescending(x => x).Take(3).ToArray();

            Console.WriteLine(String.Join(" ",input));
        }
    }
}
