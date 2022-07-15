

using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {


            var list = Console.ReadLine().Split().Select(int.Parse).ToList();

            Console.WriteLine(String.Join(" ", MergeSort(list)));
        }

        static List<int> MergeSort(List<int> input)
        {
            if (input.Count == 1)
            {
                return input;
            }
            var middle = input.Count / 2;
            var list1 = MergeSort(input.GetRange(0, middle));
            var list2 = MergeSort(input.GetRange(middle, input.Count - middle));

            return CombineLists(list1, list2);
        }


        private static List<int> CombineLists(List<int> list1, List<int> list2)
        {
            var combined = new List<int>();
            int list1Index = 0;
            int list2Index = 0;

            while (list1Index < list1.Count && list2Index < list2.Count)
            {
                if (list1[list1Index] <= list2[list2Index])
                {
                    combined.Add(list1[list1Index]);
                    list1Index++;
                }

                else
                {
                    combined.Add(list2[list2Index]);
                    list2Index++;


                }
            }

            for (int i = list1Index; i < list1.Count; i++)
            {
                combined.Add(list1[i]);
            }

            for (int i = list2Index; i < list2.Count; i++)
            {
                combined.Add(list2[i]);
            }

            return combined;

        }
    }
}
