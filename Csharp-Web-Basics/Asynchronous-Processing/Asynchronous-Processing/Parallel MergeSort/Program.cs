namespace Parallel_MergeSort
{

    // C# program for Merge Sort
    using System;
    using System.Diagnostics;

    class MergeSort
    {

        class MergeSortHelper<T>
        {
            private readonly IComparer<T> _comparer;

            public MergeSortHelper()
                : this(Comparer<T>.Default)
            {
            }

            public MergeSortHelper(IComparer<T> comparer)
            {
                _comparer = comparer;
            }

            public void MergeSort(T[] array, int low, int high, bool parallel)
            {
                // Create a copy of the original array. Switching between
                // original array and its copy will allow to avoid 
                // additional array allocations and data copying.
                var copy = (T[])array.Clone();
                if (parallel)
                    ParallelMergeSort(array, copy, low, high, GetMaxDepth());
                else
                    SequentialMergeSort(array, copy, low, high);
            }

            private void SequentialMergeSort(T[] to, T[] temp, int low, int high)
            {
                if (low >= high)
                    return;
                var mid = (low + high) / 2;
                // On the way down the recursion tree both arrays have 
                // the same data so we can switch them. Sort two 
                // sub-arrays first so that they are placed into the temp 
                // array.
                SequentialMergeSort(temp, to, low, mid);
                SequentialMergeSort(temp, to, mid + 1, high);
                // Once temp array contains two sorted sub-arrays
                // they are merged into target array.
                SequentialMerge(to, temp, low, mid, mid + 1, high, low);
                // On the way up either we are done as the target array
                // is the original array and now contains required 
                // sub-array sorted or it is the temp array from previous 
                // step and contains smaller sub-array that will be 
                // merged into the target array from previous step 
                // (which is the temp array of this step and so we 
                // can destroy its contents).
            }

            // Although sub-arrays being merged in sequential version 
            // are adjacent that is not the case for parallel version 
            // and thus sub-arrays boundaries must be specified 
            // explicitly.
            private void SequentialMerge(T[] to, T[] temp, int lowX, int highX, int lowY, int highY, int lowTo)
            {
                var highTo = lowTo + highX - lowX + highY - lowY + 1;
                for (; lowTo <= highTo; lowTo++)
                {
                    if (lowX > highX)
                        to[lowTo] = temp[lowY++];
                    else if (lowY > highY)
                        to[lowTo] = temp[lowX++];
                    else
                        to[lowTo] = Less(temp[lowX], temp[lowY])
                                        ? temp[lowX++]
                                        : temp[lowY++];
                }
            }

            private bool Less(T x, T y)
            {
                return _comparer.Compare(x, y) < 0;
            }

            private const int SEQUENTIAL_THRESHOLD = 2048;

            // Recursion depth is utilized to limit number of spawned 
            // tasks. 
            private void ParallelMergeSort(T[] to, T[] temp, int low, int high, int depth)
            {
                if (high - low + 1 <= SEQUENTIAL_THRESHOLD || depth <= 0)
                {
                    // Resort to sequential algorithm if either 
                    // recursion depth limit is reached or sub-problem 
                    // size is not big enough to solve it in parallel.
                    SequentialMergeSort(to, temp, low, high);
                    return;
                }

                var mid = (low + high) / 2;
                // The same target/temp arrays switching technique 
                // as in sequential version applies in parallel 
                // version. sub-arrays are independent and thus can 
                // be sorted in parallel.
                depth--;
                Parallel.Invoke(
                    () => ParallelMergeSort(temp, to, low, mid, depth),
                    () => ParallelMergeSort(temp, to, mid + 1, high, depth)
                    );
                // Once both taks ran to completion merge sorted 
                // sub-arrays in parallel.
                ParallelMerge(to, temp, low, mid, mid + 1, high, low, depth);
            }

            // As parallel merge is itself recursive the same mechanism
            // for tasks number limititation is used (recursion depth).
            private void ParallelMerge(T[] to, T[] temp, int lowX, int highX, int lowY, int highY, int lowTo, int depth)
            {
                var lengthX = highX - lowX + 1;
                var lengthY = highY - lowY + 1;

                if (lengthX + lengthY <= SEQUENTIAL_THRESHOLD || depth <= 0)
                {
                    // Resort to sequential algorithm in case of small 
                    // sub-problem or deep recursion.
                    SequentialMerge(to, temp, lowX, highX, lowY, highY, lowTo);
                    return;
                }

                if (lengthX < lengthY)
                {
                    // Make sure that X range no less than Y range and 
                    // if needed swap them.
                    ParallelMerge(to, temp, lowY, highY, lowX, highX, lowTo, depth);
                    return;
                }

                // Get median of the X sub-array. As X sub-array is 
                // sorted it means that X[lowX .. midX - 1] are less 
                // than or equal to median and X[midx + 1 .. highX] 
                // are greater or equal to median.
                var midX = (lowX + highX) / 2;
                // Find element in the Y sub-array that is strictly 
                // greater than X[midX]. Again as Y sub-array is 
                // sorted Y[lowY .. midY - 1] are less than or equal 
                // to X[midX] and Y[midY .. highY] are greater than 
                // X[midX].
                var midY = BinarySearch(temp, lowY, highY, temp[midX]);
                // Now we can compute final position in the target 
                // array of median of the X sub-array.
                var midTo = lowTo + midX - lowX + midY - lowY;
                to[midTo] = temp[midX];
                // The rest is to merge X[lowX .. midX - 1] with 
                // Y[lowY .. midY - 1] and X[midx + 1 .. highX] 
                // with Y[midY .. highY] preceeding and following 
                // median respectively in the target array. As 
                // pairs are idependent from their final position 
                // perspective they can be merged in parallel.
                depth--;
                Parallel.Invoke(
                    () => ParallelMerge(to, temp, lowX, midX - 1, lowY, midY - 1, lowTo, depth),
                    () => ParallelMerge(to, temp, midX + 1, highX, midY, highY, midTo + 1, depth)
                    );
            }

            // Searches for index the first element in low to high 
            // range that is strictly greater than provided value 
            // and all elements within specified range are smaller 
            // or equal than index of the element next to range is 
            // returned.
            private int BinarySearch(T[] from, int low, int high, T lessThanOrEqualTo)
            {
                high = Math.Max(low, high + 1);
                while (low < high)
                {
                    var mid = (low + high) / 2;
                    if (Less(from[mid], lessThanOrEqualTo))
                        low = mid + 1;
                    else
                        high = mid;
                }
                return low;
            }

            private static int GetMaxDepth()
            {
                // Although at each step we split unsorted array
                // into two equal size sub-arrays sorting them 
                // not be perfectly balanced because parallel merge 
                // may not be balanced. So we add some extra space for 
                // task creation and so will keep CPUs busy.
                return (int)Math.Log(Environment.ProcessorCount, 2) + 4;
            }
        }


        public class Benchmark
        {
            public static IEnumerable<long> Run<T>(Func<int, T[]> generator, Action<T[]> action, int times)
            {
                var samples = new long[times];
                var sw = new Stopwatch();
                for (var i = 0; i < times; i++)
                {
                    var input = generator(i);
                    sw.Restart();
                    action(input);
                    sw.Stop();
                    samples[i] = sw.ElapsedMilliseconds;
                }
                return samples;
            }
        }


        const int count = 10 * 1000 * 1000;
        const int iterations = 10;

        static void Main()
        {
            var rnd = new Random();

            var input = new int[count];
            Func<int, int[]> gen = i =>
            {
                // Avoid allocating large array for every
                // run and just fill existing one 
                for (var j = 0; j < input.Length; j++)
                    input[j] = rnd.Next();

                return input;
            };

            Action<int[]> seqArraySort, parallelQuickSort, parallelMergeSort;
            // If Array.Sort<T>(T[] a, IComparer<T> c) sees 
            // Comparer<T>.Default it resorts to unmanaged CLR provided 
            // sorting implementation, so we use here dummy comparer to 
            // force it to use managed quicksort.
           
            // Our parallel merge sort implementation
            parallelMergeSort = a => new MergeSortHelper<int>().MergeSort(a, 0, a.Length - 1, true);

           // var sq = Benchmark.Run(gen, seqArraySort, iterations).Average();
           // var pq = Benchmark.Run(gen, parallelQuickSort, iterations).Average();


            //var pm = Benchmark.Run(gen, parallelMergeSort, 1).Average();

            var stopwatch = new Stopwatch();
            gen.Invoke(0);
            stopwatch.Start();

            parallelMergeSort.Invoke(input);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);

            gen.Invoke(0);
            var syncMergeSort = new MergeSortSync();
            stopwatch.Restart();
            

            syncMergeSort.sort(input, 0, input.Length - 1);

            stopwatch.Stop();

            Console.WriteLine(stopwatch.Elapsed);

        }
      


    }

    public class MergeSortSync
    {

        // Merges two subarrays of []arr.
        // First subarray is arr[l..m]
        // Second subarray is arr[m+1..r]
       void merge(int[] arr, int l, int m, int r)
        {
            // Find sizes of two
            // subarrays to be merged
            int n1 = m - l + 1;
            int n2 = r - m;

            // Create temp arrays
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            // Copy data to temp arrays
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            // Merge the temp arrays

            // Initial indexes of first
            // and second subarrays
            i = 0;
            j = 0;

            // Initial index of merged
            // subarray array
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            // Copy remaining elements
            // of L[] if any
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            // Copy remaining elements
            // of R[] if any
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // Main function that
        // sorts arr[l..r] using
        // merge()
      public  void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                // Find the middle
                // point
                int m = l + (r - l) / 2;

                // Sort first and
                // second halves
                sort(arr, l, m);
                sort(arr, m + 1, r);

                // Merge the sorted halves
                merge(arr, l, m, r);
            }
        }

        // A utility function to
        // print array of size n */
        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        // Driver code

    }
}

    // This code is contributed by Princi Singh


