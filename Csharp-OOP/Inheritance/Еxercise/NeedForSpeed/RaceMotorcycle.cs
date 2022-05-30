using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
   public class RaceMotorcycle : Motorcycle
    {
        const double defaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower,double fuel):base(horsePower,fuel) 
        {

        }
        public override double FuelConsumption { get => defaultFuelConsumption; set { } }
    }
}
