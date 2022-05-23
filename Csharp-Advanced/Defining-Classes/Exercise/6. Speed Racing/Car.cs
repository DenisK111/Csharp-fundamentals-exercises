using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    /* •	string Model
•	double FuelAmount
•	double FuelConsumptionPerKilometer
•	double Travelled distance
*/
    public class Car
    {

        public Car(string model, double fuelAmmount, double fuelConsumptionKm)

        {
            TravelledDistance = 0;
            Model = model;
            FuelAmmount = fuelAmmount;
            FuelComsumptionKilometer = fuelConsumptionKm;
        }

        public string Model { get; set; }
        public double FuelAmmount { get; set; }
        public double FuelComsumptionKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double ammountOfKm)
        {
            if (FuelAmmount >= ammountOfKm * FuelComsumptionKilometer)
            {
                TravelledDistance += ammountOfKm;
                FuelAmmount -= ammountOfKm * FuelComsumptionKilometer;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
