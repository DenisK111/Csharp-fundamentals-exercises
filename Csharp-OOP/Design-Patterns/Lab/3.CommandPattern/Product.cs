using System;
using System.Collections.Generic;
using System.Text;

namespace _3.CommandPattern
{
    class Product
    {
       

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }



        public void IncreasePrice(int ammount)
        {

            Price += ammount;

            Console.WriteLine($"Price increased by {ammount}" );
        }

        public void DecreasePrice(int ammount)
        {
            if (ammount<Price)
            {
                Price -= ammount;
                Console.WriteLine($"Price decrease by {ammount}");
            }
            
        }

        public override string ToString()
        {
            return $"Current price for the Product: {Name} is {Price}";
        }



    }
}
