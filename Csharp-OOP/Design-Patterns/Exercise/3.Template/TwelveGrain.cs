using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Template
{
    class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Baking the {this.GetType().Name} Bread"); 
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Mixing Ingredients for the {this.GetType().Name} Bread");
        }


    }
}
