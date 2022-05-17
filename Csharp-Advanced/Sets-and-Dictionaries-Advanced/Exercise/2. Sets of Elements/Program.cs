using System;
using System.Collections.Generic;

namespace _2._Sets_of_Elements
{
    class Program
    {

        /* Create a program that prints a set of elements. On the first line, you will receive two numbers - n and m, which represent the lengths of two separate sets. On the next n + m lines, you will receive n numbers, which are the numbers in the first set, and m numbers, which are in the second set. Find all the unique elements that appear in both of them and print them in the order in which they appear in the first set - n.
For example:
Set with length n = 4: {1, 3, 5, 7}
Set with length m = 3: {3, 4, 5}
Set that contains all the elements that repeat in both sets -> {3, 5}
*/

        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                nSet.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < m; i++)
            {
                mSet.Add(int.Parse(Console.ReadLine()));
            }

            nSet.IntersectWith(mSet);

            Console.WriteLine(String.Join(" ",nSet));

        }
    }
}
