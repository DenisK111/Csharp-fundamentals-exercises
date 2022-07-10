namespace Recursive_Array_Sum
{
    using System;
    using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        {
            var array = Console.ReadLine()!.Split().Select(int.Parse).ToArray();

            Console.WriteLine(GetSum(array,0));
        }
        
        public static int GetSum(int[] arr,int index)
        {
            if (index == arr.Length)
            {
                return 0;
            }

            return arr[index] + GetSum(arr, index + 1);

        }
    }
}