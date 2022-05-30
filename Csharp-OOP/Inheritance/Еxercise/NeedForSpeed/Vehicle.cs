using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    /* Create a base class Vehicle. It should contain the following members:
•	A constructor that accepts the following parameters: int horsePower, double fuel
•	DefaultFuelConsumption – double 
•	FuelConsumption – virtual double
•	Fuel – double
•	HorsePower – int
•	virtual void Drive(double kilometers)
o	The Drive method should have a functionality to reduce the Fuel based on the traveled kilometers.
The default fuel consumption for Vehicle is 1.25*/
    public class Vehicle
    {
        const double  defaultFuelConsumption = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }

        
        public virtual double FuelConsumption { get { return defaultFuelConsumption; } set { } }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * this.FuelConsumption;

        }
    }
}
