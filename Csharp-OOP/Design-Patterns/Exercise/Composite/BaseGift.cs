using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public abstract class BaseGift
    {
        protected string name;
        protected int price;

        protected BaseGift(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public abstract int CalculateTotalPrice(); 
    }
}
