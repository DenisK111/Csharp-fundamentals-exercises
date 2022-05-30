namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
           

            
            Fish fish1 = new Fish("Cipura", 50);
            Cake cake = new Cake("Torta");
            Cake cake2=new Cake("Ime",)
           

            System.Console.WriteLine(fish1.Grams);
            System.Console.WriteLine(fish1.Name);
            System.Console.WriteLine(fish1.Price);

            Coffee coffee = new Coffee("Machiatto", 2);
            System.Console.WriteLine(coffee.Name);
            System.Console.WriteLine(coffee.Mililiters);
            System.Console.WriteLine(coffee.Caffeine);
            System.Console.WriteLine(coffee.Price);
            
        }
    }
}