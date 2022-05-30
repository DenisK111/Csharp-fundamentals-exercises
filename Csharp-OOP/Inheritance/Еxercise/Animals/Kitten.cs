using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        string sound = "Meow";
      

        public Kitten(string name, int age) : base(name, age, "Female")
        {


        }
        protected override string Sound { get { return this.sound; } set { } }
    }
}
