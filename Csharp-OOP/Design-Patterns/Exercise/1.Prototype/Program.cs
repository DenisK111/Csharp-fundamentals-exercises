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
            Hamburger copyBurger = menu["FishBurger"].Clone() as Hamburger;

            Console.WriteLine(copyBurger);

            

            Console.WriteLine(new string('-',50));

           // Hamburger copy = menu["Fishburger"].Clone() as Hamburger;

            foreach (var (key,value) in menu)
            {
                Console.WriteLine(key);
                Console.WriteLine(value);
            }


        }
    }
}
