using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    /* Each person should have a name, money, and a bag of products. Each product should have a name and a cost. The name cannot be an empty string. Money cannot be a negative number. 
Create a program where each command corresponds to a person buying a product. If the person can afford a product, add it to his bag. If a person doesn’t have enough money, print an appropriate message ("{personName} can't afford {productName}").
On the first two lines, you are given all people and all products. After all, purchases print every person in the order of appearance and all products that he has bought also in order of appearance. If nothing was bought, print the name of the person followed by "Nothing bought". 
In case of invalid input (negative money Exception message: "Money cannot be negative") or an empty name (empty name Exception message: "Name cannot be empty") break the program with an appropriate message. See the examples below:
*/
    public class Person
    {
        private string name;
        private List<Product> products;
        private decimal money;

        public Person(string name,decimal money)
        {
            if (money < 0)
                throw new ArgumentException("Money cannot be negative");
            Name = name;
            products = new List<Product>();
            this.money = money;
            

        }

        public string Name
        {
            get { return name; }
            private set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;

                 }
        }

        public IReadOnlyCollection<Product> Products => products.AsReadOnly();
        
        public void Buy(Func<string, Product> product,string productInput)
        {
            if (product(productInput).Cost>this.money)
            {
                Console.WriteLine($"{this.Name} can't afford {product(productInput).Name}");
            }

            else
            {
                money -= product(productInput).Cost;
                Console.WriteLine($"{this.Name} bought {product(productInput).Name}");
                products.Add(product(productInput));
            }

        }

        public override string ToString()
        {
            if (products.Count > 0)
            {
                return $"{this.Name} - {String.Join(", ", products)}";

            }

            else return $"{this.Name} - Nothing bought";
        }

    }
}
