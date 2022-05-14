using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace _9._Simple_Text_Editor
{
    class Program
    {
        /* You are given an empty text. Your task is to implement 4 commands related to manipulating the text
•	1 someString - appends someString to the end of the text
•	2 count - erases the last count elements from the text
•	3 index - returns the element at position index from the text
•	4 - undoes the last not undone command of type 1 / 2 and returns the text to the state before that operation
Input
•	The first line contains n, the number of operations.
•	Each of the following n lines contains the name of the operation followed by the command argument, if any, separated by space in the following format "CommandName Argument".
Output
•	For each operation of type 3 print a single line with the returned character of that operation.
Constraints
•	1 ≤ N ≤ 105
•	The length of the text will not exceed 1000000
•	All input characters are English letters.
•	It is guaranteed that the sequence of input operations is possible to perform.
*/
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stackStates = new Stack<Stack<char>>();
            var charStack = new Stack<char>();
            
          stackStates.Push(new Stack<char>());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();
                switch (command[0])
                {

                    case "1":

                        command[1].ToCharArray().ToList().ForEach(charStack.Push);
                        stackStates.Push(new Stack<char>(charStack));
                        break;
                    case "2":

                        for (int i1 = 0; i1 < int.Parse(command[1]); i1++)
                        {
                            charStack.Pop();
                        }
                        if (int.Parse(command[1]) != 0)
                        {
                            stackStates.Push(new Stack<char>(charStack));
                        }
                        
                        break;
                    case "3":
                        Console.WriteLine(stackStates.Peek().ElementAt(int.Parse(command[1]) - 1));

                        break;
                    case "4":
                     stackStates.Pop();
                        charStack = new Stack<char>(stackStates.Peek());
                        break;
                    default:
                        break;
                }

            }
             
        }
    }
}
