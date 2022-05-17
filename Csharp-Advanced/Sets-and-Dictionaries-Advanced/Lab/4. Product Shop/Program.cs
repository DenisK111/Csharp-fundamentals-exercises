using System;
using System.Collections.Generic;

namespace _4._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shopList = new SortedDictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(", ");

                if (command[0] == "Revision")
                {
                    break;
                }
                string shop = command[0];
                string product = command[1];
                double price = double.Parse(command[2]);

                if (!shopList.ContainsKey(shop))
                {
                    shopList[shop] = new Dictionary<string, double>();
                }

                shopList[shop].Add(product, price);


            }

            foreach (var item in shopList)
            {
                Console.WriteLine($"{item.Key}->");

                foreach (var product in item.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
