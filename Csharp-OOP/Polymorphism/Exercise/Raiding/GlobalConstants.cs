using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public static class GlobalConstants
    {

        public static readonly Dictionary<string, int> powerDictionary = new Dictionary<string, int>() { 
            ["Druid"] = 80,
            ["Paladin"] = 100,
            ["Rogue"] = 80,
            ["Warrior"] = 100,
        };
    }
}
