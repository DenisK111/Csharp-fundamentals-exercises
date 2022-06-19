using System;

namespace _3.CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ModifyPrice priceModifier = new ModifyPrice();

            Product product = new Product("Ferrari", 100000);
            Console.WriteLine(product);
            priceModifier.Invoke(new ProductCommand(product, ProductEnumeration.PriceActions.IncreasePrice, 200000));

            Console.WriteLine(product);


        }
    }
}
