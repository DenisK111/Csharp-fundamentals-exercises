using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class GenericSwap
    {

        public static void Swap<T>(List<T> list, int index1, int index2)
        {
            var temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;

            foreach (var item in list)
            {
                Console.WriteLine($"{item.GetType()}: {item}");
            }


        }
    }
}
