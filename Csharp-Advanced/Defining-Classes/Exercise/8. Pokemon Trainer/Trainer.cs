using System.Collections.Generic;

namespace DefiniingClasses
{
    /* Trainers have:
•	Name
•	Number of badges
•	A collection of pokemon*/
    public class Trainer
    {
        public Trainer(string name)
        {
            Pokemons = new List<Pokemon>();
            Badges = 0;
            Name = name;
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

    }
}