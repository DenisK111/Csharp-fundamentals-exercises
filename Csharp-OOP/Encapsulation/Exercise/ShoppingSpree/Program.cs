using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] peopleInput = Console.ReadLine().Split(new char[] { ';','='},StringSplitOptions.RemoveEmptyEntries );
            string[] productsInput = Console.ReadLine().Split(new char[] { ';', '=' },StringSplitOptions.RemoveEmptyEntries);

          
            List<Person> listOfPeople = new List<Person>();
            List<Product> productInventory = new List<Product>();
            for (int i = 0; i < peopleInput.Length; i+=2)
            {
               
                    string name = peopleInput[i];
                    decimal money = decimal.Parse(peopleInput[i + 1]);
                try
                {
                    listOfPeople.Add(new Person(name, money));

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }


            }

            for (int i = 0; i < productsInput.Length; i+=2)
            {
                    string name = productsInput[i];
                    decimal cost = decimal.Parse(productsInput[i + 1]);
                
                try
                {
                    productInventory.Add(new Product(name, cost));

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            while (true)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "END")
                {
                    break;
                }

                string person = command[0];
                string productInput = command[1];
               Func<string,Product> product = x=> productInventory.FirstOrDefault(y=>y.Name == x);

                listOfPeople.FirstOrDefault(x => x.Name == person).Buy(product, productInput);
            }

            foreach (var person in listOfPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}
