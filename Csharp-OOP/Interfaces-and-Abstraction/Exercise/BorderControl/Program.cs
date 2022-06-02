using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, IBuyer> listOfBuyers = new Dictionary<string, IBuyer>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command.Length == 4)
                {
                    listOfBuyers[command[0]] = new Citizen(command[0],int.Parse(command[1]),command[2],command[3]);
                }


                else
                {
                    listOfBuyers[command[0]] = new Rebel(command[0], int.Parse(command[1]), command[2]);



                }
            }

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End")
                {
                    break;
                }

                if (listOfBuyers.ContainsKey(name))
                {
                    listOfBuyers[name].BuyFood();
                }
            }

            Console.WriteLine(listOfBuyers.Sum(x=>x.Value.Food));
        }
    }
}
