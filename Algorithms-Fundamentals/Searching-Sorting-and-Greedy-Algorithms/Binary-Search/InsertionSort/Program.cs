using System;
using System.Linq;

namespace InsertionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 1; i < array.Length; i++)
            {
                var j = i;

                while (j>0 && array[j-1] > array[j])
                {
                    var temp = array[j - 1];
                    array[j - 1] = array[j];
                    array[j] = temp;

                    j--;
                }
            }

            Console.WriteLine(String.Join(" ",array));
        }
    }
}
