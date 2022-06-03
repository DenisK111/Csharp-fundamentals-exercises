using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
    public abstract class Animal : IAnimal
    {

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; }
        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public string AskForFood()
        {
            return GlobalConstants.animalSounds[GetType().Name];

        }
        protected Action<IFood> EatFood => x => { FoodEaten += x.Qantity; Weight += x.Qantity * GlobalConstants.foodIncreaseAmmount[this.GetType().Name]; };
        protected Action<IFood> doesNotEat => x => Console.WriteLine($"{this.GetType().Name} does not eat {x.GetType().Name}!");
        public virtual void Eat(IFood food) => EatFood(food);


    }
}
