using System;
using System.Collections.Generic;
using System.Text;


namespace _3.CommandPattern
{
    class ProductCommand : ICommand
    {
        private readonly Product product;
        private readonly ProductEnumeration.PriceActions priceAction;
        private readonly int ammount;

        public ProductCommand(Product product, ProductEnumeration.PriceActions priceAction, int ammount)
        {
            this.product = product;
            this.priceAction = priceAction;
            this.ammount = ammount;
        }

        public void ExecuteCommand()
        {
            if (priceAction == ProductEnumeration.PriceActions.IncreasePrice)
            {
                product.IncreasePrice(ammount);
            }

            else if (priceAction==ProductEnumeration.PriceActions.DecreasePrice)
            {
                product.DecreasePrice(ammount);
            }
           
        }
    }
}
