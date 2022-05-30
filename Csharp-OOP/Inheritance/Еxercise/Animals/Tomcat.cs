using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
   public class Tomcat : Cat
    {
        string sound = "MEOW";
       

        public Tomcat(string name,int age) : base(name, age, "Male")
        {


        }
        protected override string Sound { get { return this.sound; } set { } }
    }
}
