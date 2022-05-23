using System;
using System.Collections.Generic;

namespace Memoization
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> values = new Dictionary<int, int>() { 
            [1] = 1,[2] = 1 };
            Console.WriteLine(Fib(8,values));
        }

        private static int Fib(int n,Dictionary<int,int> values)
        {
           
           
            if (values.ContainsKey(n))
            {
                return values[n];
            }

      values.Add(n, Fib(n - 1, values) + Fib(n - 2, values));
            

            return values[n];

        }
    }
}
