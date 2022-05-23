using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
   public class Cargo
    {
        public Cargo(string type,int weight)
        {
            Type = type;
            Weight = weight;
        }
        public int Weight { get; set; }
        public string Type { get; set; }
    }
}
