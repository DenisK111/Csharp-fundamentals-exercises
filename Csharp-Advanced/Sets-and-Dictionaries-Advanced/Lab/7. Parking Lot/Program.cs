using System;
using System.Collections.Generic;

namespace _7._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {

            var parkingRecords = new HashSet<string>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "END")
                {
                    break;
                }

                var action = command[0];
                var record = command[1];

                if (action == "IN")
                {
                    parkingRecords.Add(record);
                }

                else
                {
                    parkingRecords.Remove(record);
                }
            }
            if (parkingRecords.Count > 0)
            {

                foreach (var item in parkingRecords)
                {
                    Console.WriteLine(item);
                }
            }

            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
