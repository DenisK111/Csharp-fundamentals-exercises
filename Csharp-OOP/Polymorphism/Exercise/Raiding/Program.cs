using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
                List<IHero> heroes = new List<IHero>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                IHero hero = Factory.CreateHero(name, type);
                if (hero == null)
                {
                    i--;
                    continue;
                }
                heroes.Add(hero);
            }

            int bossPower = int.Parse(Console.ReadLine());

            heroes.ForEach(x => Console.WriteLine(x.CastAbility()) );
            if (heroes.Sum(x=>x.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }

            else
            {
                Console.WriteLine("Defeat...");
            }


        }
    }
}
