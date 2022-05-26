using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
       public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }

            int[] indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            GenericSwap.Swap(list,indexes[0],indexes[1]);
           
        }

        
    }
}
