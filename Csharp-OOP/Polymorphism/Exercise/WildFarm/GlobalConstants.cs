using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm
{
   public static class GlobalConstants
    {
        public static readonly Dictionary<string, double> foodIncreaseAmmount = new Dictionary<string, double> { 
            ["Hen"] = 0.35,
            ["Owl"] = 0.25,
            ["Mouse"] = 0.10,
            ["Cat"] = 0.30,
            ["Dog"] = 0.40,
            ["Tiger"] = 1.00,
        };

        public static readonly Dictionary<string, string> animalSounds = new Dictionary<string, string>
        {
            ["Hen"] = "Cluck",
            ["Owl"] = "Hoot Hoot",
            ["Mouse"] = "Squeak",
            ["Cat"] = "Meow",
            ["Dog"] = "Woof!",
            ["Tiger"] = "ROAR!!!"

        };
    }
}
