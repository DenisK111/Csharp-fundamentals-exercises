using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiniingClasses
{
    class StartUp
    {

        /* You will be receiving lines until you receive the command "Tournament". Each line will carry information about a pokemon and the trainer who caught it in the format:
"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"
TrainerName is the name of the Trainer who caught the pokemon. Trainers’ names are unique.
After receiving the command "Tournament", you will start receiving commands until the "End" command is received. They can contain one of the following:
•	"Fire"
•	"Water"
•	"Electricity"
For every command, you must check if a trainer has at least 1 pokemon with the given element. If he does, he receives 1 badge. Otherwise, all of his pokemon lose 10 health. If a pokemon falls to 0 or less health, he dies and must be deleted from the trainer’s collection. In the end, you should print all of the trainers, sorted by the number of badges they have in descending order (if two trainers have the same amount of badges, they should be sorted by order of appearance in the input) in the format: 
"{trainerName} {badges} {numberOfPokemon}"
*/
        
        static void Main(string[] args)
        {

            HashSet<Trainer> trainers = new HashSet<Trainer>();


            while (true)
            {

                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "Tournament")
                {
                    break;
                }

                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElement = command[2];
                int pokemonHealth = int.Parse(command[3]);

                if (trainers.FirstOrDefault(x=>x.Name == trainerName) == null)
                {
                Trainer trainer = new Trainer(trainerName);
                trainers.Add(trainer);
                trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                }

                else
                {
                    trainers.First(x => x.Name == trainerName).Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }


            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                foreach (var item in trainers)
                {
                    if (item.Pokemons.FirstOrDefault(x=>x.Element==command) != null)
                    {
                        item.Badges++;
                    }

                    else
                    {
                        item.Pokemons.ForEach(x => x.Health -= 10);
                        item.Pokemons.RemoveAll(x => x.Health <= 0);
                    }
                }

            }

            foreach (var item in trainers.OrderByDescending(x=>x.Badges))
            {
                Console.WriteLine($"{item.Name} {item.Badges} {item.Pokemons.Count}");
            }
        }
    }
}
