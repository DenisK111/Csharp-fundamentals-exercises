using System;
using WildFarm.Food;
using WildFarm.Animals;
using System.Collections.Generic;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            /* •	Felines - "{Type} {Name} {Weight} {LivingRegion} {Breed}"
  •	Birds - "{Type} {Name} {Weight} {WingSize}"
  •	Mice and Dogs - "{Type} {Name} {Weight} {LivingRegion}"
  */
            string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            IAnimal animal = null;
            IFood food = null;
            List<IAnimal> listOfAnimals = new List<IAnimal>();
            Feeder feeder = new Feeder();

            while (true)
            {
                if (command[0] == "End")
                {
                    break;
                }

                if (count % 2 == 0)
                {
                   
                    string type = command[0];
                    string name = command[1];
                    double weight = double.Parse(command[2]);

                    if (command.Length == 5)
                    {
                      animal =   Factory.CreateAnimal(type, name, weight, command[3], command[4]);
                    }

                    else if (double.TryParse(command[3], out double wingsize))
                    {
                       animal =  Factory.CreateAnimal(type, name, weight, wingsize);
                    }

                    else
                    {
                       animal =  Factory.CreateAnimal(type, name, weight, command[3]);
                    }
                    listOfAnimals.Add(animal);
                }

                else
                {
                    string foodName = command[0];
                    int foodQty = int.Parse(command[1]);
                    food = Factory.CreateFood(foodName, foodQty);
                    Console.WriteLine(animal.AskForFood());
                    feeder.Feed(animal, food);
                    
                }
                count++;
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            listOfAnimals.ForEach(Console.WriteLine);


        }
    }
}
