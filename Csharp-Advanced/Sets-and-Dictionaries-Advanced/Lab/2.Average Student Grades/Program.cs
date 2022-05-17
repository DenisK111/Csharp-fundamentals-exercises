using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var studentGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                if (!studentGrades.ContainsKey(input[0]))
                {
                    studentGrades.Add(input[0],new List<decimal>()); 
                }

                studentGrades[input[0]].Add(decimal.Parse(input[1]));

            }

            foreach (var item in studentGrades)
            {
                Console.Write($"{item.Key} -> ");

                foreach (var entry in item.Value)
                {
                    Console.Write($"{entry:f2} ");
                    
                }

                Console.WriteLine($"(avg: {item.Value.Average():f2})");
            }


        }
    }
}
