using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;

        private Dough dough;
        private List<Topping> toppings;
        private decimal totalCalories;

        public Pizza(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length>15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }

            this.name = name;
            toppings = new List<Topping>();
        }
        public string Name => name;

        public int ToppingsCount => toppings.Count;

        public decimal TotalCalories => totalCalories;

        public void AddDough(Dough dough)
        {
            if (this.dough != null){

                Console.WriteLine("Pizza already has a dough!");
                return;
            }

            this.dough = dough;
            totalCalories += dough.Calories;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count>10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
            totalCalories += topping.Calories;
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.TotalCalories} Calories.";
        }
    }
}
