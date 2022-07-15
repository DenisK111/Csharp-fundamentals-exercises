


using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list1 = Enumerable.Range(1,100000).ToList();
            List<int> list2 = Enumerable.Range(1, 100000).Reverse().ToList();

            for (int i = 0; i < list2.Count; i++)
            {
                if (i%2==0)
                {
                    var temp = list2[i];
                    list2.Remove(list2[i]);
                    list2.Add(temp);

                }
            }
           Stopwatch watch = new Stopwatch();
           // var sorted = new List<int>();
           watch.Start();
            ImprovedQuickSort(list2, 0, list2.Count - 1);
           // sorted = QuickSort(list);
           watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            watch.Reset();
          watch.Start();
            ImprovedQuickSort(list1, 0, list1.Count - 1);
            watch.Stop();
           Console.WriteLine(watch.ElapsedMilliseconds);
          //Console.WriteLine(String.Join(",",sorted));
           // Console.WriteLine(String.Join(" ",list1));




        }


        private static List<int> QuickSort(List<int> input)
        {


            if (input.Count == 0)
            {
                return new List<int>();
            }

            int pivot = input[input.Count / 2];

            List<int> leftList = new List<int>();
            List<int> rightList = new List<int>();
            List<int> pivotList = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < pivot)
                {
                    leftList.Add(input[i]);
                }

                else if (input[i] > pivot)
                {
                    rightList.Add(input[i]);
                }

                else
                {
                    pivotList.Insert(0, input[i]);
                }
            }

            return QuickSort(leftList).Concat(pivotList).Concat(QuickSort(rightList)).ToList();



        }

        public static void ImprovedQuickSort(List<int> input, int start, int end)
        {

            if (start >= 0 && end >= 0 && start < end)
            {
                int middle = Partition(input, start, end);
                ImprovedQuickSort(input, start, middle);
                ImprovedQuickSort(input, middle + 1, end);
            }

            static int Partition(List<int> input, int start, int end)
            {

                int pivot = input[(start + end) / 2];
                int i = start - 1;
                int j = end + 1;

                while (true)
                {
                    do
                    {
                        i++;
                    } while (input[i] < pivot);

                    do
                    {
                        j--;
                    } while (input[j] > pivot);

                    if (i >= j)
                        return j;

                    var temp = input[i];
                    input[i] = input[j];
                    input[j] = temp;
                }


            }
            /* algorithm quicksort(A, lo, hi) is 
              if lo >= 0 && hi >= 0 && lo < hi then
                p := partition(A, lo, hi) 
                quicksort(A, lo, p) // Note: the pivot is now included
                quicksort(A, p + 1, hi) 
            // Divides array into two partitions
            algorithm partition(A, lo, hi) is 
              // Pivot value
              pivot := A[ floor((hi + lo) / 2) ] // The value in the middle of the array
              // Left index
              i := lo - 1 
              // Right index
              j := hi + 1
              loop forever 
                // Move the left index to the right at least once and while the element at
                // the left index is less than the pivot
                do i := i + 1 while A[i] < pivot

                // Move the right index to the left at least once and while the element at
                // the right index is greater than the pivot
                do j := j - 1 while A[j] > pivot
                // If the indices crossed, return
                if i ≥ j then return j

                // Swap the elements at the left and right indices
                swap A[i] with A[j]*?
            */
        }




    }
}
