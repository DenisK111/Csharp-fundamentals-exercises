using System;

namespace CarManufacturer
{
    class StartUp
    {

        public static void Main(string[] args)
        {
            Car car = new Car();
            car.Make = "VW";
            car.Model = "MK3";
            car.Year = 1992;

            Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}{Environment.NewLine}Year: {car.Year}");
        }
    }
}
