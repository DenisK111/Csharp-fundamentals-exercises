using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Action_Point
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> printString = x => Console.WriteLine(x);
            Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(printString);

        }
    }
}
