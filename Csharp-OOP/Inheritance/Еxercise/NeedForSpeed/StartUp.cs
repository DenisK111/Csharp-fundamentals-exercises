namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Car car = new Car(100, 100);
            car.Drive(20);
            System.Console.WriteLine(car.Fuel);

            SportCar car1 = new SportCar(100, 100);
            car1.Drive(20);
            System.Console.WriteLine(car1.Fuel);
        
           var bike = new RaceMotorcycle(100, 100);
            bike.Drive(20);
            System.Console.WriteLine(bike.Fuel);
        }
    }
}
