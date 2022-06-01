using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
   public class Topping
    {
        private readonly Dictionary<string, decimal> toppings;
        private const decimal BaseQuantifier = 2m;
        private decimal calories;

        private readonly KeyValuePair<string, decimal> meat = new KeyValuePair<string, decimal>("meat", 1.2m);
        private readonly KeyValuePair<string, decimal> veggies = new KeyValuePair<string, decimal>("veggies", 0.8m);
        private readonly KeyValuePair<string, decimal> cheese = new KeyValuePair<string, decimal>("cheese", 1.1m);
        private readonly KeyValuePair<string, decimal> sauce = new KeyValuePair<string, decimal>("sauce", 0.9m);
        public Topping(string topping,decimal grams)
        {
            
            toppings = new Dictionary<string, decimal> { [meat.Key] = meat.Value, [veggies.Key] = veggies.Value, [cheese.Key] = cheese.Value, [sauce.Key] = sauce.Value };
            CalculateCalories(topping, grams);
            
            }

        public decimal Calories => calories;
        

        private void CalculateCalories(string topping,decimal grams)
        {
            if (grams<1 || grams>50)
            {
                throw new ArgumentException($"{topping} weight should be in the range [1..50].");
            }

            if (!toppings.ContainsKey(topping.ToLowerInvariant()))
            {
                throw new ArgumentException($"Cannot place {topping} on top of your pizza.");
            }

            var quantifier = toppings[toppings.Keys.First(x => x == topping.ToLowerInvariant())];

            this.calories = BaseQuantifier * quantifier * grams;

        }
    }
}
