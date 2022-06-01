using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {

                Pizza pizza = null;
            while (true)
            {
                string[] command = Console.ReadLine().Split(" ");

                if (command[0] == "END")
                {
                    Console.WriteLine(pizza);
                    break;
                }
                string pizzaPart = command[0];
                try
                {
                    switch (pizzaPart)
                    {
                        case "Pizza": 

                            pizza = new Pizza(command[1]);
                            break;
                        case "Dough":

                            Dough dough = new Dough(command[1], command[2], decimal.Parse(command[3]));


                            pizza.AddDough(dough);

                           // Console.WriteLine(dough.Calories);
                            break;

                        case "Topping":
                            Topping topping = new Topping(command[1], decimal.Parse(command[2]));
                            pizza.AddTopping(topping);
                            //Console.WriteLine(topping.Calories);
                            break;
                    }
                }

                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }

            }

            


        }
    }
}
