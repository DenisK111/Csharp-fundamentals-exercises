using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Car_Salesman
{
    public class StartUp
    {
       public static void Main(string[] args)
        {

            int enginesNum = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();
            List<Car> carList = new List<Car>();
            for (int i = 0; i < enginesNum; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                Engine engine;
                if (engineData.Length == 3)
                {
                    bool displacementExists = int.TryParse(engineData[2], out int displacement);

                    if (displacementExists)
                    {
                         engine = new Engine(model, power, displacement);
                    }

                    else
                    {
                         engine = new Engine(model, power, engineData[2]);
                    }
                }

                else if (engineData.Length == 4)
                {
                     engine = new Engine(model, power, int.Parse(engineData[2]), engineData[3]);
                }

                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            int numOfCars = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];
                string engineModel = input[1];
                    Car car;
                if (input.Length == 3)
                {
                    bool weightExists = int.TryParse(input[2], out int weight);
                    if (weightExists)
                    {
                        car = new Car(model, engines.FirstOrDefault(x => x.Model == engineModel), weight);
                    }

                    else
                    {
                        car = new Car(model, engines.FirstOrDefault(x => x.Model == engineModel),input[2]);
                    }


                }

                else if (input.Length == 4)
                {
                    car = new Car(model, engines.First(x => x.Model == engineModel), int.Parse(input[2]), input[3]);
                }

                else
                {
                    car = new Car(model, engines.First(x => x.Model == engineModel));
                }
                carList.Add(car);
            }

            foreach (var item in carList)
            {
                Console.WriteLine(item.ToString());
            }

        }
    }
}
