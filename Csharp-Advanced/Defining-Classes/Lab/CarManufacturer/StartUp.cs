using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            HashSet<Car> listOfCars = new HashSet<Car>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires")
                {
                    break;
                }

                string[] tireInfo = command.Split();

                
                tires.Add(new Tire[]{ new Tire(int.Parse(tireInfo[0]),double.Parse(tireInfo[1])),
                    new Tire(int.Parse(tireInfo[2]),double.Parse(tireInfo[3])),
                    new Tire(int.Parse(tireInfo[4]),double.Parse(tireInfo[5])),
                    new Tire(int.Parse(tireInfo[6]),double.Parse(tireInfo[7]))}

                    );


            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engines done")
                {
                    break;
                }

                string[] enginesInput = command.Split();

                int horsePower = int.Parse(enginesInput[0]);
                double cubicCapacity = double.Parse(enginesInput[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Show special")
                {
                    break;
                }



                string[] carInfo = command.Split();

                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int tiresIndex = int.Parse(carInfo[5]);
                int enginesIndex = int.Parse(carInfo[6]);

                listOfCars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[enginesIndex], tires[tiresIndex]));


            }

            

            foreach (var item in listOfCars.Where(x=> x.Year>=2017 && x.Engine.HorsePower>330 && x.Tires.Sum(x=>x.Pressure)>9 && x.Tires.Sum(x => x.Pressure) < 10))
            {
                item.Drive(20);
                Console.WriteLine($"Make: {item.Make}\nModel: {item.Model}\nYear: {item.Year}\nHorsePowers: {item.Engine.HorsePower}\nFuelQuantity: {item.FuelQuantity}");
            }

        }
    }
}
