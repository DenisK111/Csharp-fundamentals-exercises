using System;

namespace _2.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            CarBuilderFacade carFacade = new CarBuilderFacade();
            var car = carFacade.Built.AtAddress("bul.Ruski").InCity("Plovidv").Info.WithType("Mazda").WithColor("Green").WithNumberOfDoors(4).Build();
            Console.WriteLine(car);
        }
    }
}
