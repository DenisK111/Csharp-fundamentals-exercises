using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : DrivableFuelableVehicle
    {
        double summerModifier = 1.4;
        public Bus(double fuelQty, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQty, fuelConsumptionPerKm, tankCapacity)
        {
        }

        protected override double SummerModifier => summerModifier;
        public void DriveEmpty(double distance)
        {
            this.summerModifier = 0;

            base.Drive(distance);

            this.summerModifier = 1.4;
        }
    }
}
