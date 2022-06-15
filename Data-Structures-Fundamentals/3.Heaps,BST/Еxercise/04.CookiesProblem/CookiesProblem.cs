using System;
using Wintellect.PowerCollections;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        public int Solve(int k, int[] cookies)
        {
            OrderedBag<int> bag = new OrderedBag<int>(cookies);
            if (bag.Count == 0)
            {
                return -1;
            }

            int operations = 0;
            if (bag[0] >= k)
            {
                return operations;
            }

            if (bag.Count == 1)
            {
                return -1;
            }

            while (true)
            {

                var leastSweet = bag[0];
                var secondLeastSweet = bag[1];
                bag.RemoveFirst();
                bag.RemoveFirst();
                bag.Add(leastSweet + 2 * secondLeastSweet);
                operations++;
                if (bag.CountWhere(x => x < k) == 0)
                {
                    return operations;
                }
                if (bag.Count<2)
                {
                    return -1;
                }
                     
                   


                

            }
            
           
        }
    }
}
