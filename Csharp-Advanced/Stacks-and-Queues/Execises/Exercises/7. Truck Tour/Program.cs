using System;
using System.Linq;
using System.Collections.Generic;

namespace _7._Truck_Tour
{
    class Program
    {

        /* Suppose there is a circle. There are N petrol pumps on that circle. Petrol pumps are numbered 0 to (N−1) (both inclusive). You have two pieces of information corresponding to each of the petrol pumps: (1) the amount of petrol that particular petrol pump will give, and (2) the distance from that petrol pump to the next petrol pump.
Initially, you have a tank of infinite capacity carrying no petrol. You can start the tour at any of the petrol pumps. Calculate the first point from where the truck will be able to complete the circle. Consider that the truck will stop at each of the petrol pumps. The truck will move one kilometer for each liter of petrol.
Input
•	The first line will contain the value of N
•	The next N lines will contain a pair of integers each, i.e. the amount of petrol that petrol pump will give and the distance between that petrol pump and the next petrol pump
Output
•	An integer which will be the smallest index of the petrol pump from which we can start the tour
Constraints
•	1 ≤ N ≤ 1000001
•	1 ≤ Amount of petrol, Distance ≤ 1000000000
*/
        static void Main(string[] args)
        {
            int totalPumps = int.Parse(Console.ReadLine());
            var listOfPumps = new List<PetrolPump>();

            for (int i = 0; i < totalPumps; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var pump = new PetrolPump(input[0], input[1]);
                listOfPumps.Add(pump);
            }

            int successIndex = 0;

            var pumpsQueue = new Queue<PetrolPump>(listOfPumps);
            while (true)
            {
                int indexReached = 0;
                bool fail = false;
                int currentCapacity = 0;

                foreach (var item in pumpsQueue)
                {
                    currentCapacity += item.Ammount - item.Distance;
                    indexReached++;
                    if (currentCapacity < 0)
                    {
                        fail = true;
                        break;
                    }

                }
                if (fail)
                {
                    successIndex += indexReached;
                }

                else
                {
                    Console.WriteLine(successIndex);
                    return;
                }


                for (int i = 0; i < indexReached; i++)
                {
                    var temp = pumpsQueue.Peek();
                    pumpsQueue.Dequeue();
                    pumpsQueue.Enqueue(temp);
                }


            }




        }


    }

    class PetrolPump
    {

        public PetrolPump(int ammountOfPetrol, int distance)
        {
            Ammount = ammountOfPetrol;
            Distance = distance;

        }
        public int Ammount { get; set; }
        public int Distance { get; set; }


    }
}
