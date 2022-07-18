using System;
using System.Collections.Generic;

namespace Fibonacci
{
    internal class Program
    {
        static Dictionary<int, long> memo; 
        static void Main(string[] args)
        {
            memo = new Dictionary<int, long>();
            Console.WriteLine(Fibonacci(int.Parse(Console.ReadLine())));
        }

        private static long Fibonacci(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n<= 1)
            {
                return n;
            }

            var result = Fibonacci(n - 1) + Fibonacci(n - 2);
            memo[n] = result;

            return memo[n];

        }
    }
}
