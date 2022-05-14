using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _8._Balanced_Patrenthesis
{
    class Program
    {
        /* Given a sequence consisting of parentheses, determine whether the expression is balanced. A sequence of parentheses is balanced if every open parenthesis can be paired uniquely with a closing parenthesis that occurs after the former. Also, the interval between them must be balanced. You will be given three types of parentheses: (, {, and [.
{[()]} - This is a balanced parenthesis.
{[(])} - This is not a balanced parenthesis.
Input
•	Each input consists of a single line, the sequence of parentheses.
Output 
•	For each test case, print on a new line "YES" if the parentheses are balanced. 
Otherwise, print "NO". Do not print the quotes.
Constraints
•	1 ≤ lens ≤ 1000, where the lens is the length of the sequence.
•	Each character of the sequence will be one of {, }, (, ), [, ].
*/
        static void Main(string[] args)
        {
            char[] par = Console.ReadLine().ToCharArray();

            var parStack = new Stack<char>();

            Regex openRegex = new Regex(@"[{\(\[]");
            
            string result = "YES";
            foreach (var item in par)
            {
                if (openRegex.IsMatch(item.ToString()))
                {
                    parStack.Push(item);
                }

                else if (parStack.Count == 0)
                {
                    result = "NO";
                    break;
                }

                else if (item == '}')
                {
                    if (parStack.Peek()!='{')
                    {
                        result = "NO";
                        break;
                    }
                    parStack.Pop();
                }

                else if (item == ']')
                {
                    if (parStack.Peek() != '[')
                    {
                        result = "NO";
                        break;
                    }
                    parStack.Pop();
                }

                else if (item == ')')
                {
                    if (parStack.Peek() != '(')
                    {
                        result = "NO";
                        break;
                    }
                    parStack.Pop();
                }
            }

            
            Console.WriteLine(result);

        }
    }
}
