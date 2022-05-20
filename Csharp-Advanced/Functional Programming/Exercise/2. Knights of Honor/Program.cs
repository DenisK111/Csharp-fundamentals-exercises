using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Action<string> printString = x => Console.WriteLine(x);
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().Select(x=> "Sir " + x).ToList().ForEach(printString);

        }
    }
}
