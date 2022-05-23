using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelConsumption;
        double fuelQunatíty;
        Engine engine;
        Tire[] tires;


        public Car(string make,string model,int year,double fuelQuantity,double fuelConsumption,Engine engine,Tire[] tires) : this(make, model,year,fuelQuantity,fuelConsumption)
        {
            Engine = engine;
            Tires = tires;
        }
        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;

        }

        public Car(string make,string model, int year, double fuelQuantity, double fuelConsumption) : this(make,model,year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make,string model,int year) : this()
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public int Year { get; set; }
        public Engine Engine { get; set; }
        public Tire[] Tires { get; set; }
        public string Make {
            get
            {
                return this.make;
            }
                
            set
            {
                this.make = value;
            }
                
        }
        public string Model { get; set; }

        public double FuelConsumption { get; set; }
        public double FuelQuantity { get; set; }

        public void Drive(Double distance)
        {

            if (FuelQuantity - FuelConsumption * distance/100 > 0)
            {
                FuelQuantity -= FuelConsumption * distance/100;
            }

            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {

            return $"Make: {Make}\nModel: {Model}{Environment.NewLine}Year: {Year}\nFuel: {FuelQuantity:f2}";
        }
    }
}
