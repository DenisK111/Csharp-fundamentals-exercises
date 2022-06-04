using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    class Truck : DrivableFuelableVehicle
    { 
        
        public Truck(double fuelQty, double fuelConsumptionPerKm,double tankCapacity) : base(fuelQty, fuelConsumptionPerKm,tankCapacity)
        {
        }

        protected override double SummerModifier => 1.6;
      
    }
}
