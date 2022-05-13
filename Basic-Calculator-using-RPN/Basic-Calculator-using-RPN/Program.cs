using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace Basic_Calculator_using_RPN
{
    class Program // This is a basic calculator based on Reverse Polish Notation working only with operators "+, -, *, /". Input is in infix notations, output is the result calculated by RPN.
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Expression:");
                string input = Console.ReadLine();

                Regex regexForNums = new Regex(@"(\d+\.?\d*)|[+\-*\/]");

                MatchCollection numMatches = regexForNums.Matches(input);

                List<string> expression = numMatches.Select(x => x.ToString()).ToList();

                Stack<decimal> reversePolishNotationCalc = new Stack<decimal>();
                Stack<string> operatorStack = new Stack<string>();
                bool divideByZero = false;
                for (int i = 0; i < expression.Count; i++)
                {
                    if (!Regex.Match(expression[i], @"[+\-*\/]").Success)
                    {
                        reversePolishNotationCalc.Push(decimal.Parse(expression[i]));
                        if (operatorStack.Count != 0)
                        {
                            if (operatorStack.Peek() == "*")
                            {
                                operatorStack.Pop();
                                reversePolishNotationCalc.Push(reversePolishNotationCalc.Pop() * reversePolishNotationCalc.Pop());
                            }

                            else if (operatorStack.Peek() == "/")
                            {
                                operatorStack.Pop();
                                decimal divisor = reversePolishNotationCalc.Pop();
                                if (divisor == 0)
                                {
                                    Console.WriteLine("Cannot divide by 0!");
                                    divideByZero = true;
                                    break;

                                }
                                reversePolishNotationCalc.Push(reversePolishNotationCalc.Pop() / divisor);
                            }
                        }
                    }

                    else
                        operatorStack.Push(expression[i]);  // 3 * 2;
                }

                if (!divideByZero)
                {

                    reversePolishNotationCalc = new(reversePolishNotationCalc);
                    operatorStack = new(operatorStack);

                    while (reversePolishNotationCalc.Count > 1)
                    {
                        switch (operatorStack.Peek())
                        {
                            case "+":
                                operatorStack.Pop();
                                reversePolishNotationCalc.Push(reversePolishNotationCalc.Pop() + reversePolishNotationCalc.Pop());
                                break;
                            case "-":
                                operatorStack.Pop();
                                // decimal subtrahend = finalCacl.Pop();
                                reversePolishNotationCalc.Push(reversePolishNotationCalc.Pop() - reversePolishNotationCalc.Pop());

                                break;

                        }

                    }


                    Console.WriteLine("Result:");
                    Console.WriteLine(reversePolishNotationCalc.Pop());
                    Console.WriteLine("---------------");
                }
            }
        }
    }
}
