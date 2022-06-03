using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
   public interface IFuelable
    {
        public double FuelQty { get; }
        public double FuelConsumptionPerKm { get; }
        public double TankCapacity { get; }
        public void Refuel(double ammount);
    }
}
