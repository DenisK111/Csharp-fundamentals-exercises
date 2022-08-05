using Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;

namespace RealEstateConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            var config = new Config();
            var serviceProvider = config.ConfigureServices(new ServiceCollection());




            const int optionsCount = 4;
            while (true)
            {
                Reset();


                var input = Console.ReadLine();

                if (int.TryParse(input, out int option) && option <= optionsCount && option >= 0)
                {
                    switch (option)
                    {
                        case 0: Environment.Exit(0); break;
                        case 1:


                            while (true)
                            {


                                Console.WriteLine("Please enter details");
                                Console.WriteLine("size: ");

                                Dictionary<string, bool> checks = new Dictionary<string, bool>();

                                checks["Size"] = int.TryParse(Console.ReadLine(), out int size);
                                Console.WriteLine("Yard Size: ");
                                checks["Yard Size"] = int.TryParse(Console.ReadLine(), out int yardSize);
                                Console.WriteLine("Floor: ");
                                checks["Floor"] = byte.TryParse(Console.ReadLine(), out byte floor);
                                Console.WriteLine("Total Floors: ");
                                checks["Total Floors"] = byte.TryParse(Console.ReadLine(), out byte totalFloors) ? totalFloors >= floor ? true : false : false;
                                Console.WriteLine("year: ");
                                checks["Year"] = int.TryParse(Console.ReadLine(), out int year);
                                Console.WriteLine("Price: ");
                                checks["Price"] = int.TryParse(Console.ReadLine(), out int price);
                                Console.WriteLine("Property Type: ");
                                string type = Console.ReadLine()!;
                                Console.WriteLine("Building Type: ");
                                string buildingType = Console.ReadLine()!;
                                Console.WriteLine("District: ");
                                string district = Console.ReadLine()!;

                                bool checksPassed = true;
                                foreach (var kvp in checks)
                                {
                                    if (!kvp.Value)
                                    {
                                        Console.WriteLine($"Incorrect {kvp.Key}! Please enter details again. Presee any key to enter details again");
                                        Console.ReadKey();
                                        checksPassed = false;
                                        break;
                                    }
                                }

                                if (checksPassed)
                                {
                                    serviceProvider.GetRequiredService<IPropertyService>().Add(size, yardSize, floor, totalFloors, district, year, type, buildingType, price);
                                    Console.WriteLine("Property Added Successfully!");
                                    break;
                                }

                                Reset();
                            }





                            break;
                        case 2:
                            var result = serviceProvider.GetRequiredService<IPropertyService>().GetListOfNeighbourhoodsOrderedByHighestPrice();

                            var counter = 1;
                            foreach (var district in result)
                            {
                                Console.WriteLine($"{counter++}. {district.Name} ({district.AvaragePrice:f2}€)");

                            }

                            break;

                        case 3:

                            var resultPerSqm = serviceProvider.GetRequiredService<IPropertyService>().GetAvaragePricePerSqmPerDistrict();

                            var counterPerSqm = 1;
                            foreach (var district in resultPerSqm)
                            {
                                Console.WriteLine($"{counterPerSqm++}. {district.Name} ({district.Price:f2}€)");

                            }


                            break;

                        case 4:

                            while (true)
                            {

                                Console.WriteLine("From: ");
                                bool num1 = int.TryParse(Console.ReadLine(), out int from);
                                Console.WriteLine("To: ");
                                bool num2 = int.TryParse(Console.ReadLine(), out int to);
                                if (num1 && num2)
                                {
                                    Console.WriteLine($"Avarage price: {serviceProvider.GetRequiredService<IPropertyService>().GetAvaragePriceBySquareMeters(from,to):f2}€");
                                    break;
                                }


                                Console.WriteLine("Incorrect Format!");
                                Console.WriteLine("Press any key to enter data again");
                                Console.ReadKey();
                                Reset();
                            }
                            break;
                        default:
                            break;
                    }


                }


                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }


        }

        private static void Reset()
        {
            Console.Clear();
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Add Property");
            Console.WriteLine("2. Get Districts Ordereded By Avarage Price Of Property");
            Console.WriteLine("3. Get Districts Ordereded By Avarage Price Of Property Per Square Meter");
            Console.WriteLine("4. Get Avarage Price In square meters range");
            Console.WriteLine("0. Exit");
        }
    }
}