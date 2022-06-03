using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight,string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {

            base.Eat(food);
            }

            else
            {
                doesNotEat(food);
            }

        }
    }
}
