using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Food

{
    public abstract class Food : IFood
    {
        protected Food(int qantity)
        {
            Qantity = qantity;
        }

        public int Qantity { get; set; }
    }
}
