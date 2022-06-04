namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            char[] par = parentheses.ToCharArray();

            var parStack = new Stack<char>();

            Regex openRegex = new Regex(@"[{\(\[]");
            
            foreach (var item in par)
            {
                if (openRegex.IsMatch(item.ToString()))
                {
                    parStack.Push(item);
                }

                else if (parStack.Count == 0)
                {
                    return false;
                    
                }

                else if (item == '}')
                {
                    if (parStack.Peek() != '{')
                    {
                        return false;
                       
                    }
                    parStack.Pop();
                }

                else if (item == ']')
                {
                    if (parStack.Peek() != '[')
                    {
                        return false;
                        
                    }
                    parStack.Pop();
                }

                else if (item == ')')
                {
                    if (parStack.Peek() != '(')
                    {
                        return false;
                        
                    }
                    parStack.Pop();
                }
            }
            return true;

        }
    }
}
