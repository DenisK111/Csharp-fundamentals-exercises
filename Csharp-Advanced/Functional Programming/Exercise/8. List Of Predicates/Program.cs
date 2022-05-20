using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());
            IEnumerable<int> rangeToAdd = Enumerable.Range(1, endOfRange);
            List<int> range = new List<int>(rangeToAdd);
            List<int> dividers = Console.ReadLine().Split().Select(int.Parse).ToList();
            dividers = dividers.Distinct().ToList();
            List<int> validRange = new List<int>();
            Action<List<int>> validNums = x =>
            {

                range.ForEach(y =>
                {
                    bool valid = true;
                    for (int i = 0; i < dividers.Count; i++)
                    {
                        valid = y % dividers[i] == 0 ? true : false;
                        if (!valid)
                        {
                            break;
                        }
                    }

                    if (valid)
                    {
                        validRange.Add(y);
                    }

                });


                
                

            };

            validNums(range);
            Console.WriteLine(String.Join(" ",validRange));


        }


    }
}
