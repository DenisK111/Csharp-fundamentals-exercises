using System;
using System.Collections.Generic;

namespace _3._Periodic_Table
{
    class Program
    {
        /*
         * 
         * Create a program that keeps all the unique chemical elements. On the first line, you will be given a number n - the count of input lines that you are going to receive. On the next n lines, you will be receiving chemical compounds, separated by a single space. Your task is to print all the unique ones in ascending order:*/
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            SortedSet<string> periodicTable = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (var item in input)
                {
                    periodicTable.Add(item);
                }
            }

            Console.WriteLine(String.Join(" ",periodicTable));
        }
    }
}
