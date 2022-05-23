using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        /* A car's model is unique - there will never be 2 cars with the same model. On the first line of the input, you will receive a number N – the number of cars you need to track. On each of the next N lines, you will receive information about a car in the following format: 
"{model} {fuelAmount} {fuelConsumptionFor1km}"
All cars start at 0 kilometers traveled. After the N lines, until the command "End" is received, you will receive commands in the following format: 
"Drive {carModel} {amountOfKm}"
Implement a method in the Car class to calculate whether or not a car can move that distance. If it can, the car’s fuel amount should be reduced by the amount of used fuel and its traveled distance should be increased by the number of the traveled kilometers. Otherwise, the car should not move (its fuel amount and the traveled distance should stay the same) and you should print on the console:
"Insufficient fuel for the drive"
After the "End" command is received, print each car and its current fuel amount and the traveled distance in the format:
 "{model} {fuelAmount} {distanceTraveled}"
Print the fuel amount formatted two digits after the decimal separator.
*/
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> carList = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = parameters[0];
                double fuelAmmount = double.Parse(parameters[1]);
                double fuelConsumptionKm = double.Parse(parameters[2]);

                Car car = new Car(model, fuelAmmount, fuelConsumptionKm);
                carList.Add(car);

            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "End")
                {
                    break;
                }
                string model = commands[1];
                double km = double.Parse(commands[2]);

                carList[carList.IndexOf(carList.First(x => x.Model == model))].Drive(km);
            }
            foreach (var car in carList)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmmount:f2} {car.TravelledDistance}");
            }


        }
    }
}
