using System;

namespace _1.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu["Hamburger"] = new Hamburger("Bacon", "Lettuce", "Bun", "Ketchup");
            menu["ChickenBurger"] = new Hamburger("Chicken", "Lettuce", "Bun", "Ketchup");
            //menu["FishBurger"] = new Hamburger("Fish", "Lettuce", "Bun", "Ketchup");


            Hamburger porkburger = new Hamburger("Pork", "Lettuce", "Bun", "Ketchup");

            menu["PorkBurger"] = porkburger;


            menu["FishBurger"] = new Hamburger("Fish", "Lettuce", "Bun", "Ketchup");
            Hamburger copyBurger = porkburger.Clone() as Hamburger;

            Console.WriteLine(porkburger.Meat);
            Console.WriteLine(copyBurger.Meat);

            copyBurger.Meat = "Fish";

            Console.WriteLine(porkburger.Meat);
            Console.WriteLine(copyBurger.Meat);







        }
    }
}
