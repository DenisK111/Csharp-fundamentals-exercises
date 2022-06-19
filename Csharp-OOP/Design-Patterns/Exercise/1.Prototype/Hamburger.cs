using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Prototype
{
    class Hamburger : HamburgerPrototype
    {
        string meat;
        string veggies;
        string bread;
        string sauces;

        public Hamburger(string meat, string veggies, string bread, string sauces)
        {
            this.meat = meat;
            this.veggies = veggies;
            this.bread = bread;
            this.sauces = sauces;
        }
        public string Meat { get { return meat; } set { meat = value; } }
        public override HamburgerPrototype Clone()
        {
            return this.MemberwiseClone() as HamburgerPrototype;
        }
        public override string ToString() => $"1. {this.meat} 2.{this.veggies} 3.{this.bread} 4.{this.sauces}";
    }
}
