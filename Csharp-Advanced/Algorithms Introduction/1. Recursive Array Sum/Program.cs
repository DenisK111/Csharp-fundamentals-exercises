using System;

namespace _1._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 1, 2, 3, 4, 5,6 };
            Console.WriteLine(Traverse(array, 0)); 
        }

        private static int Traverse(int[] array, int n)
        {
            if (n==array.Length)
            {
                return 0 ;
            }

            return array[n] + Traverse(array, n + 1);
        }
    }
}
