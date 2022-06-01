using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private readonly Dictionary<string, decimal> flourType;
        private readonly Dictionary<string, decimal> bakingTechnique;
        private const decimal BaseQuantifier = 2m;

        private decimal calories;


        public Dough(string flourType, string bakingTechnique, decimal grams)
        {
            this.flourType = new Dictionary<string, decimal> { ["white"] = 1.5m, ["wholegrain"] = 1.0m };
            this.bakingTechnique = new Dictionary<string, decimal> { ["crispy"] = 0.9m, ["chewy"] = 1.1m, ["homemade"] = 1.0m };
            CalculateCalories(flourType, bakingTechnique, grams);
        }


        public decimal Calories => calories;

        private void CalculateCalories(string flourType, string bakingTechnique, decimal grams)
        {
            if (!this.flourType.ContainsKey(flourType.ToLowerInvariant()) || !this.bakingTechnique.ContainsKey(bakingTechnique.ToLowerInvariant()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }

            if (grams < 1 || grams > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            decimal typeModifier = this.flourType[this.flourType.Keys.First(x => x == flourType.ToLowerInvariant())];
            decimal techniqueModifier = this.bakingTechnique[this.bakingTechnique.Keys.FirstOrDefault(y => y == bakingTechnique.ToLowerInvariant())];

            this.calories = BaseQuantifier * typeModifier * techniqueModifier * grams;
        }
    }
}
