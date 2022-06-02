using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        string name;
        string favouriteFood;

        protected Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        protected string Name { get; set; }
        protected string FavouriteFood { get; set; }

        public virtual string ExplainSelf()
        {

            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
    }
}
