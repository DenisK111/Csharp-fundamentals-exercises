﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Template
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();

        public virtual void Slice()
        {

            Console.WriteLine($"Slicing the {this.GetType().Name} Bread");
        }

        public void Make()
        {

            MixIngredients();
            Bake();
            Slice();
        }
    }
}
