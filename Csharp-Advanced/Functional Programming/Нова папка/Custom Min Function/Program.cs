using System;
using System.Linq;
using System.Collections.Generic;


namespace Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNum = x => x.Min();
            Console.WriteLine(minNum(Console.ReadLine().Split().Select(int.Parse).ToArray()));
        }
    }
}
