using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimal_Element
{
    class Program
    {

        /* You have an empty sequence, and you will be given N queries. Each query is one of these three types:
1 x – Push the element x into the stack.
2 – Delete the element present at the top of the stack.
3 – Print the maximum element in the stack.
4 – Print the minimum element in the stack.
After you go through all of the queries, print the stack in the following format:
"{n}, {n1}, {n2} …, {nn}"
Input
•	The first line of input contains an integer, N
•	The next N lines each contain an above-mentioned query. (It is guaranteed that each query is valid)
Output
•	For each type 3 or 4 queries, print the maximum/minimum element in the stack on a new line
Constraints
•	1 ≤ N ≤ 105
•	1 ≤ x ≤ 109
•	1 ≤ type ≤ 4
•	If there are no elements in the stack, don’t print anything on commands 3 and 4
*/

        static void Main(string[] args)
        {
            int numberOfQueries = int.Parse(Console.ReadLine());
            Stack<int> intStack = new Stack<int>();
            for (int i = 0; i < numberOfQueries; i++)
            {
                int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (command[0])
                {
                    case 1:
                        intStack.Push(command[1]);

                        break;
                    case 2:
                        intStack.Pop();
                        break;
                    case 3:

                        if (intStack.Count > 0)
                        {
                            Console.WriteLine(intStack.Max());

                        }
                        break;
                    case 4:

                        if (intStack.Count > 0)
                        {
                            Console.WriteLine(intStack.Min());
                        }
                        break;
                }

            }

            Console.WriteLine(String.Join(", ",intStack));


        }
    }
}
