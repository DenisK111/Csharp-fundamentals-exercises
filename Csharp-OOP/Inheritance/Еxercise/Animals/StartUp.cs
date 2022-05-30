using System.Collections.Generic;
using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Beast!")
                {
                    break;
                }
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = command[0];
                int age = int.Parse(command[1]);

                Animal animal;

                switch (input)
                {
                    case"Dog":
                        animal = new Dog(name, age, command[2]);
                        break; 
                    case"Cat":
                        animal = new Cat(name, age, command[2]);
                        break; 
                    case"Frog":
                        animal = new Frog(name, age, command[2]);
                        break; 
                    case"Tomcat":
                        animal = new Tomcat(name, age); break; 
                    case"Kitten":
                        animal = new Kitten(name, age);break;
                    default:animal = new Animal(name, age, command[2]);
                        break; 
                }

                if (!animal.IsFailed)
                {
                    animals.Add(animal);
                    
                }

                else
                {
                    animal = null;
                }


            }

            Console.WriteLine(String.Join($"{Environment.NewLine}",animals));
            
        }
    }
}
