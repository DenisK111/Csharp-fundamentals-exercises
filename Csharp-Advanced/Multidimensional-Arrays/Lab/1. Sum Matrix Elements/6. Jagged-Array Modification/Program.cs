using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = ReadJaggedArray();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "END")
                {
                    break;
                }

                int row = int.Parse(command[1]); 
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);
                if (row>= 0 && row< jaggedArray.Length) 
                {
                    if (col >= 0 && col < jaggedArray[row].Length)
                    {
                jaggedArray[row][col] = jaggedArray[row][col] + (command[0] == "Add" ? value : -value);

                    }

                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }

                }

                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

            }

            PrintJaggedArray(jaggedArray);


        }
      
        static int[][] ReadJaggedArray()
        {
            int n = int.Parse(Console.ReadLine());
            
            int[][] jaggedArray = new int[n][];



            for (int i = 0; i < n; i++)
            {
            int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[i] = new int[rowsCols.Length];

                for (int element = 0; element < jaggedArray[i].Length; element++)
                {
                    jaggedArray[i][element] = rowsCols[element];
                }
            }

            return jaggedArray;
        }

        static void PrintJaggedArray(int[][] jaggedArray)
        {

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(String.Join(" ",row));

            }
            
        }
    }
}
