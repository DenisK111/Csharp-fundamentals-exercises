using System;
using System.Collections.Generic;

namespace Salaries
{
    internal class Program
    {
        static Dictionary<List<int>, int> memoisation;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            memoisation = new Dictionary<List<int>, int>();
            var graphMatrix = new char[n, n];

            var graphList = new List<int>[n];

            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine();
                    for (int col = 0; col < n; col++)
                {
                    graphMatrix[row, col] = input[col];

                }
            }

            
            for (int row = 0; row < n; row++)
            {

                graphList[row] = new List<int>();
                for (int col = 0; col < n; col++)
                {
                    if (graphMatrix[row,col] == 'Y')
                    {
                        
                        graphList[row].Add(col);
                    }
                }

              
            }

            var totalSum = 0;

            

            foreach (var  employee in graphList)
            {
               
                totalSum += GetTotalSum(0, graphList, employee);
            }

            Console.WriteLine(totalSum);




        }

        private static int GetTotalSum(int currSum, List<int>[] graphList, List<int> employee)
        {
            if (employee.Count == 0)
            {
                
                return 1;
            }

            if (memoisation.ContainsKey(employee))
            {
                return memoisation[employee];
            }

            else
            {
                memoisation[employee] = 0;
            }

            foreach (var person in employee)
            {

                
                
                    memoisation[employee] = memoisation[employee] + GetTotalSum(0, graphList, graphList[person]);
                    
                
            }
            return memoisation[employee];
           
        }
    }
}
