using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class DrivableFuelableVehicle : IDrivable, IFuelable
    {

        double summerModifier = 0;
        protected DrivableFuelableVehicle(double fuelQty, double fuelConsumptionPerKm,double tankCapacity)
        {
            if (fuelQty>tankCapacity)
            {
                fuelQty = 0;
            }
            FuelQty = fuelQty;
            FuelConsumptionPerKm = fuelConsumptionPerKm;
            TankCapacity = tankCapacity;
        }
        protected virtual double SummerModifier { get { return summerModifier; } set {} }
        public double FuelQty { get; private set; }

        public double FuelConsumptionPerKm { get; }

        public double TankCapacity {get;}

        public void Drive(double distance)
        {
            if (FuelQty>= distance * (FuelConsumptionPerKm + SummerModifier))
            {
            FuelQty -= distance * (FuelConsumptionPerKm + SummerModifier);
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
            }

            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }


        }


        public void Refuel(double ammount)
        {
            var temp = ammount;
            if (GetType().Name == "Truck")
            {
                temp = ammount * 0.95;
            }
            if (ammount<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (FuelQty+ammount>TankCapacity)
            {
                Console.WriteLine($"Cannot fit {ammount} fuel in the tank");
            }
            else
            {

            FuelQty += temp;
            }

        }
        
    }
}
