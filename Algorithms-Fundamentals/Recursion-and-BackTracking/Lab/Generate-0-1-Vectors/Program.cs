namespace Generate_0_1_Vectors
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine()!);
            var array = new int[n];
            //PrintAllVectors(array,array.Length-1,true);
            PrintAllVectorsCorrect(array,0);
        }

        private static void PrintAllVectorsCorrect(int[] array,int index)
        {
            if (index>= array.Length)
            {
                Console.WriteLine(String.Join("",array));
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                array[index] = i;

                 PrintAllVectorsCorrect(array, index + 1);
            }
        }

        public static void PrintAllVectors(int[] array, int index,bool print)
        {

            if (print)
            {
            Console.WriteLine(String.Join("",array));

            }
            print = true;

            if (index == -1)
            {
                return;
            }

            if (array[index] == 0)
            {
                
                array[index] = 1;
                ResetAllIndexes(array, index + 1);
            }

            else if (array[index] == 1)
            {
                if (MoveValueUp(array, array.Length - 1, index))
                {
                    index--;
                    print = false;
                }
                
            }

           
            PrintAllVectors(array, index,print);


        }

        private static bool MoveValueUp(int[] array, int startIndex,int endIndex)
        {
            if (endIndex == startIndex)
            {
                return true;
            }

            if (array[startIndex] == 0)
            {
                array[startIndex] = 1;
                ResetAllIndexes(array, startIndex + 1);
                return false;
            }

            return MoveValueUp(array, startIndex - 1, endIndex);


        }

        private static void ResetAllIndexes(int[] array, int index)
        {
            if (index == array.Length)
            {
                return;
            }

            array[index] = 0;
            ResetAllIndexes(array, index + 1);
            
        }

        
    }
}