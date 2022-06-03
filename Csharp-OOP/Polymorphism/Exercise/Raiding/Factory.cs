using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Factory
    {
        public static IHero CreateHero(string name, string type)
        {
            IHero hero = null;

            bool isValid = Enum.TryParse<ClassTypes>(type, out ClassTypes heroType);
            if (!isValid)
            {
                Console.WriteLine("Invalid hero!");

            }

            else
            {
                switch (heroType)
                {
                    case ClassTypes.Druid:
                        hero = new Druid(name, GlobalConstants.powerDictionary[type]);
                        break;
                    case ClassTypes.Paladin:
                        hero = new Paladin(name, GlobalConstants.powerDictionary[type]);
                        break;
                    case ClassTypes.Rogue:
                        hero = new Rogue(name, GlobalConstants.powerDictionary[type]);
                        break;
                    case ClassTypes.Warrior:
                        hero = new Warrior(name, GlobalConstants.powerDictionary[type]);
                        break;

                }
            }

            return hero;


        }
    }
}
