using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class SportCar : Car
    {
       const double defaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption { get => defaultFuelConsumption; set { }  }
    }
}
