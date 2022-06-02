using ExplicitInterfaces.Contracts;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0]=="End")
                {
                    break;
                }

                string name = command[0];
                string country = command[1];
                int age = int.Parse(command[2]);
                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
