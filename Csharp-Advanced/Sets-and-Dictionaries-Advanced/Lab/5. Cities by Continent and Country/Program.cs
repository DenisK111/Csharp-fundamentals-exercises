using System;
using System.Collections.Generic;

namespace _5._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cityCatalogue = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split();

                string continent = command[0];
                string country = command[1];
                string city = command[2];

                if (!cityCatalogue.ContainsKey(continent))
                {
                    cityCatalogue[continent] = new Dictionary<string, List<string>>();
                cityCatalogue[continent].Add(country, new List<string>());
                }

                else if (!cityCatalogue[continent].ContainsKey(country))
                {
                    cityCatalogue[continent][country] = new List<string>();
                }

                cityCatalogue[continent][country].Add(city);

                

            }

            foreach (var continent in cityCatalogue)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {String.Join(", ",country.Value)}");
                }

            }


        }
    }
}
