using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Food;

namespace WildFarm.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight,  double wingSize) : base(name, weight, wingSize)
        {
        }

       
        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                EatFood(food);
            }

            else
            {
                doesNotEat(food);
            }
        }
    }
}
