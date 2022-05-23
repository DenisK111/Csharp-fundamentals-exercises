using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
   public class Tire
    {
        public Tire(int year,double pressure)
        {
            Year = year;
            Pressure = pressure;
        }
        int year;
        double pressure;


        public int Year{ get; set; }
        public double Pressure{ get; set; }
    }
}
