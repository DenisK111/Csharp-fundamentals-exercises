using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Template
{
    class White : Bread
    {
        public override void Bake()
        {
            Console.WriteLine($"Now baking the {this.GetType().Name} bread");
        }

        public override void MixIngredients()
        {
            Console.WriteLine($"Now mixing ingredients for the {this.GetType().Name} bread");
        }
    }
}
