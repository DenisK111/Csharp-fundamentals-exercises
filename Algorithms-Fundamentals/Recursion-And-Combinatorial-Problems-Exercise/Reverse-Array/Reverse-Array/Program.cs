using System;
using System.Linq;

namespace Reverse_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Reverse(array,0,array.Length-1);
        }

        private static void Reverse(int[] array,int firstIndex,int secondIndex)
        {
            if (firstIndex>=secondIndex)
            {
                Console.WriteLine(String.Join(" ",array));
                return;
            }

            var temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;
            Reverse(array, firstIndex + 1, secondIndex - 1);
        }
    }
}
