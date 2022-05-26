using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            

            SortedSet <Person> sortedPeople = new SortedSet<Person>();
            HashSet <Person> People = new HashSet<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(command[0], int.Parse(command[1]));

                sortedPeople.Add(person);
                People.Add(person);

            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(People.Count);
            
        }

      
    }
}
