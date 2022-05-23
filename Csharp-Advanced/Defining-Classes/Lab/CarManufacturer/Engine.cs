using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
   public class Engine
    {

        public Engine(int horsePower,double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }
        int horsePower;
        double cubicCapacity;

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
