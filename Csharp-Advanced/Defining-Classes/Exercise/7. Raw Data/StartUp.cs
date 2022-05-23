using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses

{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> listOfCars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(input[0], int.Parse(input[1]), int.Parse(input[2]), int.Parse(input[3]), input[4], decimal.Parse(input[5]), int.Parse(input[6]), decimal.Parse(input[7]), int.Parse(input[8]), decimal.Parse(input[9]), int.Parse(input[10]), decimal.Parse(input[11]), int.Parse(input[12]));
                listOfCars.Add(car);
            }

            string key = Console.ReadLine();
            if (key=="fragile")
            {
                foreach (var item in listOfCars.Where(x=>x.Cargo.Type == key && x.Tire.Min(y=>y.Pressure)<1))
                {
                    Console.WriteLine(item.Model);
                }
            }

            else
            {
                foreach (var item in listOfCars.Where(x=>x.Engine.Power > 250 && x.Cargo.Type == key))
                {
                    Console.WriteLine(item.Model);
                }
            }
        }
    }
}