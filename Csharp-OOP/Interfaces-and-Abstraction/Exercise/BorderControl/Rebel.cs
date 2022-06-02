using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Rebel : INameable, IBuyer, IAgeable
    {
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
        }

        public int Food { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public string Group { get; set; }
        public void BuyFood()
        {
            Food += 5;
        }
    }
}
