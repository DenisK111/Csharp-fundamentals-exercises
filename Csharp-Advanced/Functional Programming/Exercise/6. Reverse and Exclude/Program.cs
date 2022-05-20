using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            int n = int.Parse(Console.ReadLine());
            input.Reverse();
            Func<int, bool> exclude = x => x % n == 0;
            Console.WriteLine(String.Join(" ",input.Where(x=>!exclude(x))));
        }
    }
}
