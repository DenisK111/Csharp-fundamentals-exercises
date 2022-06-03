using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            

            
            
            string[] commandCar = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] commandTruck = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] commandBus = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            DrivableFuelableVehicle car = new Car(double.Parse(commandCar[1]), double.Parse(commandCar[2]),double.Parse(commandCar[3]));
            DrivableFuelableVehicle truck = new Truck(double.Parse(commandTruck[1]), double.Parse(commandTruck[2]),double.Parse(commandTruck[3]));
            DrivableFuelableVehicle bus = new Bus(double.Parse(commandBus[1]), double.Parse(commandBus[2]),double.Parse(commandBus[3]));
            List<DrivableFuelableVehicle> listOfVehicles = new List<DrivableFuelableVehicle>();
            listOfVehicles.Add(car);
            listOfVehicles.Add(truck);
            listOfVehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                string vehicle = command[1];
                double ammount = double.Parse(command[2]);
                Action<DrivableFuelableVehicle> doOperation = action == "Drive" 
                    ? new Action<DrivableFuelableVehicle>(y =>  y.Drive(ammount)) 
                    : action == "DriveEmpty"
                    ? new Action<DrivableFuelableVehicle>(y => ((Bus)y).DriveEmpty(ammount))
                    : (y =>  y.Refuel(ammount));
                doOperation(listOfVehicles.First(x => x.GetType().Name == vehicle));

            }

            Console.WriteLine($"Car: {car.FuelQty:f2}");
            Console.WriteLine($"Truck: {truck.FuelQty:f2}");
            Console.WriteLine($"Bus: {bus.FuelQty:f2}");
        }
    }
}
