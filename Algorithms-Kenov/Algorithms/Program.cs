using System.Runtime.InteropServices;

namespace Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = [1, 2,5, 3,10];
            //Console.WriteLine(ArraySum(array,0));
            //DrawRecursion(10);
            //Gen01(0, new int[4]);
            //NelementsFromK([1, 2, 3, 4], new int[2], 0,0);
        }

        static int ArraySum(int[] array, int index)
        {
            if (array == null || array.Length == index) return 0;

            Console.WriteLine("Before Recursion + " + index);

            var sum = array[index] + ArraySum(array, index + 1);

            Console.WriteLine("After Recursion + " + index);

            return sum;
        }

        static void DrawRecursion(int count)
        {
            if (count is 0) return;

            Console.WriteLine(new string('*', count));

            DrawRecursion(count - 1);

            Console.WriteLine(new string('#', count));
            
        }
          
        
        static long Factorial (int num) => num <= 1 ? 1 : num * Factorial(num -1);

        static void Gen01(int index, int[] vector)
        {
            if (index >= vector.Length) Console.WriteLine(string.Join("", vector));
            else 
            {
                for (int i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    Gen01(index + 1, vector);
                }
            }
        }

        static void NelementsFromK(int[] set,int[] array, int index, int border)
        {
            if (index >= array.Length) 
                Console.WriteLine(string.Join("",array));
            else
            {
                for(int i = border ;i < set.Length;i++)
                {
                    array[index] = set[i];
                    NelementsFromK(set, array, index + 1, i + 1);
                }
            }

        }
    }   
}
