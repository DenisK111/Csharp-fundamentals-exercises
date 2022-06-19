using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    class LeafGift : BaseGift
    {
        public LeafGift(string name, int price) : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{name} with price {price}");

            return price;
        }
    }
}
