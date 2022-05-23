using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
  public  class Tire
    {
        

        public Tire(decimal pressure,int age)
        {
            Age = age;
            Pressure = pressure;
        }

        public int Age { get; set; }
        public decimal Pressure { get; set; }


        

    }
}
