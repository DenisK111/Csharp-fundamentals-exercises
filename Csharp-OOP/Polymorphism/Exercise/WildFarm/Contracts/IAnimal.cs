namespace WildFarm
{
    public interface IAnimal
    {
        int FoodEaten { get; }
        string Name { get; }
        double Weight { get;  }

        public string AskForFood();

        public void Eat(IFood food);
    }
}