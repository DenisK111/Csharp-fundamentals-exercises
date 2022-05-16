using System;
using System.Linq;
using System.Numerics;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {

        /* Create a program that populates, analyzes, and manipulates the elements of a matrix with an unequal length of its rows.
First, you will receive an integer N equal to the number of rows in your matrix.
On the next N lines, you will receive sequences of integers, separated by a single space.Each sequence is a row in the matrix.
After populating the matrix, start analyzing it.If a row and the one below it have equal length, multiply each element in both of them by 2, otherwise - divide by 2.
Then, you will receive commands. There are three possible commands:
•	"Add {row} {column} {value}" - add { value}
        to the element at the given indexes, if they are valid
•	"Subtract {row} {column} {value}" - subtract {value
    }
    from the element at the given indexes, if they are valid
•	"End" - print the final state of the matrix(all elements separated by a single space) and stop the program
Input
•	On the first line, you will receive the number of rows of the matrix - integer N
•	On the next N lines, you will receive each row - sequence of integers, separated by a single space
•	{value
}
will always be an integer number
•	Then you will be receiving commands until reading "End"
Output
•	The output should be printed on the console and it should consist of N lines
•	Each line should contain a string representing the respective row of the final matrix, elements separated by a single space
Constraints
•	The number of rows N of the matrix will be an integer in the range [2 … 12]
•	The input will always follow the format above
•	Think about data types
*/
        static void Main(string[] args)
        {
            
            var jaggedArray = ReadJaggedArray();

            for (int row = 0; row < jaggedArray.Length - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row + 1][col] *= 2;
                    }
                }

                else
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < jaggedArray[row + 1].Length; col++)
                    {

                        jaggedArray[row + 1][col] /= 2;
                    }

                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "End")
                {
                    break;
                }

                int rowNum = int.Parse(command[1]);
                int colNum = int.Parse(command[2]);
                long value = long.Parse(command[3]);

                if (rowNum < 0 || colNum < 0 || rowNum >= jaggedArray.Length || colNum >= jaggedArray[rowNum].Length)
                {
                    continue;
                }

                if (command[0] == "Add")
                {
                    jaggedArray[rowNum][colNum] += value;
                }
                else
                {
                    jaggedArray[rowNum][colNum] -= value;
                }

            }

            PrintJaggedArray(jaggedArray);



        }

        static double[][] ReadJaggedArray()
        {
            int n = int.Parse(Console.ReadLine());

           double[][] jaggedArray = new double[n][];



            for (int i = 0; i < n; i++)
            {
                int[] rowsCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArray[i] = new double[rowsCols.Length];

                for (int element = 0; element < jaggedArray[i].Length; element++)
                {
                    jaggedArray[i][element] = rowsCols[element];
                }
            }

            return jaggedArray;
        }

        static void PrintJaggedArray(double[][] jaggedArray)
        {


            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
