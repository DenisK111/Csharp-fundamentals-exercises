using System;
using System.Linq;

namespace Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var element = int.Parse(Console.ReadLine());

            BinarySearch(input, element,0,input.Length-1);
        }

        private static void BinarySearch(int[] input, int element,int start,int end)
        {
            var middle = end - start / 2;

            if (start > end)
            {
                Console.WriteLine(-1);
                return;
            }
            if (input[middle] < element)
            {
                BinarySearch(input, element, middle + 1, end);
            }

           else if (input[middle] > element)
            {
                BinarySearch(input, element, start, middle - 1);
            }

            else Console.WriteLine(middle);

           
        }
    }
}
