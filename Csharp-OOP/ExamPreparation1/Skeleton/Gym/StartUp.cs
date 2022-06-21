namespace Gym
{
    using Gym.Core;
    using Gym.Core.Contracts;
    using Gym.Models.Equipment;
    using Gym.Repositories;
    using Gym.Models.Gyms;
    using Gym.Models.Athletes;
    using Gym.Repositories.Contracts;
    using Gym.Models.Equipment.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
            IEngine engine = new Engine();
            engine.Run();


            return;
            IRepository<IEquipment> repository = new EquipmentRepository();
            repository.Add(new BoxingGloves());
            repository.Add(new BoxingGloves());
            repository.Add(new BoxingGloves());
            repository.Add(new BoxingGloves());
            repository.Add(new BoxingGloves());

            Gym gym = new WeightliftingGym("MyGym");
            gym.AddEquipment(new BoxingGloves());
            gym.AddEquipment(new BoxingGloves());
            gym.AddEquipment(new BoxingGloves());
            gym.AddEquipment(new BoxingGloves());
            gym.AddEquipment(new BoxingGloves());
            var ivan = new Weightlifter("Ivan", "motivated", 10);
            gym.AddAthlete(ivan);
            System.Console.WriteLine(ivan.Stamina);
            gym.Exercise();
            System.Console.WriteLine(ivan.Stamina);

            System.Console.WriteLine();
            System.Console.WriteLine(gym.GymInfo());
        }
    }
}
