using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
   public class Cake : Dessert
    {
        const double defaultGrams = 250;
        const double defaultCalories = 1000;
        const decimal defaultPrice = 5m;
        public Cake(string name) : base(name, defaultPrice, defaultGrams,defaultCalories)
        {

        }

       


    }
}
