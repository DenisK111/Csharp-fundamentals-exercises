using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = 10;
           // (ref int a, ref int b) => (a, b) = (b, a);
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a}");
            Console.WriteLine($"b = {b}");
        }
        public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);
    }

}
