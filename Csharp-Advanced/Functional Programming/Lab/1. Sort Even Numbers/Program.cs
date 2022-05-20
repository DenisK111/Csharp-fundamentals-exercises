using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(String.Join(", ",input.Where(x => x%2 ==0).OrderBy(x=>x)));
        }
    }
}
