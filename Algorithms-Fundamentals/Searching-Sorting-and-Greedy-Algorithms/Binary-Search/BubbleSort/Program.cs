using System;
using System.Linq;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            for (int j = 0; j < array.Length ; j++)
            {
                var isSorted = true;
                for (int i = 0; i < array.Length - 1 - j; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        var temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSorted = false;
                    }
                }

                if (isSorted)
                {
                    break;
                }
            }

            Console.WriteLine(String.Join(" ", array));

        }
    }
}
