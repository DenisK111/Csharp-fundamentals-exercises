using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    class Mouse : Mammal
    {
        public Mouse(string name, double weight,string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Vegetable || food is Fruit)
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
