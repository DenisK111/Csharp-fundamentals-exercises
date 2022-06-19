using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Composite
{
    public class CompositeGift : BaseGift,IGiftOperations
    {
        private List<BaseGift> gifts = new List<BaseGift>();
        public CompositeGift(string name, int price) : base(name, price)
        {
        }

        public void AddGift(BaseGift gift)
        {
            gifts.Add(gift);
        }

        public override int CalculateTotalPrice()
        {
            int total = 0;
            Console.WriteLine($"{name} contains the following products with prices:");
            foreach (var gift in gifts)
            {
                total+= gift.CalculateTotalPrice();
            }

            return total;
        }

        public void RemoveGift(BaseGift gift)
        {
            gifts.Remove(gift);
        }
    }
}
