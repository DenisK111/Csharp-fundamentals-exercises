using System;
using System.Linq;

namespace Nested_Loops_To_Recursion
{
    internal class Program
    {
        
        
        static void Main(string[] args)
        {
          int n = (int.Parse(Console.ReadLine()));
            var array = Enumerable.Repeat(1, n).ToArray();
            
            PrintLoops(array,0);
        }

        private static void PrintLoops(int[] array, int index)
        {
            if (index >= array.Length)
            {
                Console.WriteLine(String.Join(" ", array));
                return;
            }
            for (int i = 1; i <= array.Length; i++)
            {
                array[index] = i;

                PrintLoops(array, index + 1);
            }
        }

     








    }
    }

