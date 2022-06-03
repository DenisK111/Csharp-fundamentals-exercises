using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Car : DrivableFuelableVehicle
    {
        
        public Car(double fuelQty, double fuelConsumptionPerKm,double tankCapacity) : base(fuelQty, fuelConsumptionPerKm,tankCapacity)
        {
        }

        public override double SummerModifier => 0.9;

    }
}
