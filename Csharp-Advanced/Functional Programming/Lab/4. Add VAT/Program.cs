using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> input = Console.ReadLine().Split(", ").Select(double.Parse).ToList();
            Action<double> addVat = x => Console.WriteLine($"{x * 1.2:f2}");
            input.ForEach(addVat);
        }
    }
}
