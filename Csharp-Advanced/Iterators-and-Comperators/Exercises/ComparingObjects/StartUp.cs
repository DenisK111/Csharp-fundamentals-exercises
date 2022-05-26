using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "END")
                {
                    break;
                }

                Person person = new Person(command[0], int.Parse(command[1]), command[2]);
                listOfPeople.Add(person);
            }

            int n = int.Parse(Console.ReadLine());
            int equal = 1;
            int notEqual = 0;
            for (int i = 0; i < listOfPeople.Count; i++)
            {
                if (i==n-1)
                {
                    continue;
                }

               int result = listOfPeople[n-1].CompareTo(listOfPeople[i]);
                if (result==0)
                {
                    equal++;
                }

                else
                {
                    notEqual++;
                }

            }

            if (equal == 1)
            {
                Console.WriteLine("No matches");
                Environment.Exit(0);
            }

            else
            {
                Console.WriteLine($"{equal} {notEqual} {listOfPeople.Count}");
            }
        }
    }
}
