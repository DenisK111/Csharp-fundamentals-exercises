namespace WildFarm
    
{
    public class Feeder : IFeeder
    {

        public void Feed(IAnimal animal, IFood food) => animal.Eat(food);
    }
}