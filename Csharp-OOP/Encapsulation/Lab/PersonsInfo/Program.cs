using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstName = command[0];
                string lastName = command[1];
                int age = int.Parse(command[2]);
                decimal salary = decimal.Parse(command[3]);

                Person person = new Person(firstName, lastName, age, salary);
                persons.Add(person);
            }

            
           // decimal percentage = decimal.Parse(Console.ReadLine());

            Team team = new Team("SoftUni");
            
            
            foreach (var person in persons)
            {

                
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");



        }

    }
}
