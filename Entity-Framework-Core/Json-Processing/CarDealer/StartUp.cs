using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using CarDealer.DTO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new CarDealerContext())
            {
                // db.Database.EnsureDeleted();
                // db.Database.EnsureCreated();
                // //Problem1
                // var jsonString1 = File.ReadAllText("../../../Datasets/suppliers.json");
                // Console.WriteLine(ImportSuppliers(db, jsonString1));
                // //Problem2
                // var jsonString2 = File.ReadAllText("../../../Datasets/parts.json");
                // Console.WriteLine(ImportParts(db, jsonString2));
                // //Problem3
                //  var jsonString3 = File.ReadAllText("../../../Datasets/cars.json");
                // Console.WriteLine(ImportCars(db, jsonString3));
                // //Problem4
                // var jsonString4 = File.ReadAllText("../../../Datasets/customers.json");
                // Console.WriteLine(ImportCustomers(db, jsonString4));
                // //Problem5
                // var jsonString5 = File.ReadAllText("../../../Datasets/sales.json");
                // Console.WriteLine(ImportSales(db, jsonString5));

                //Console.WriteLine(GetOrderedCustomers(db));
                //Console.WriteLine(GetCarsFromMakeToyota(db));
                //Console.WriteLine(GetLocalSuppliers(db));
                //Console.WriteLine(GetCarsWithTheirListOfParts(db));
                //Console.WriteLine(GetTotalSalesByCustomer(db));
                //Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }



        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            // Get first 10 sales with information about the car, customer and price of the sale with and without discount.Export the list of sales to JSON in the format provided below.

            var result = context.Sales.Take(10)
                .Select(s =>
                    new
                    {
                        car = new
                        {
                            s.Car.Make,
                            s.Car.Model,
                            s.Car.TravelledDistance
                        },
                        customerName = s.Customer.Name,
                        Discount = s.Discount.ToString("f2"),
                        price = s.Car.PartCars.Sum(x=>x.Part.Price).ToString("f2"),
                        priceWithDiscount = (s.Car.PartCars.Sum(x => x.Part.Price) * (1-(s.Discount/100))).ToString("f2")


                    });

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            //Get all customers that have bought at least 1 car and get their names, bought cars count and total spent money on cars. Order the result list by total spent money descending then by total bought cars again in descending order. Export the list of customers to JSON in the format provided below.

            var result = context.Customers
                .Where(c => c.Sales.Any())
                .OrderByDescending(c => c.Sales.Count())
                .ThenByDescending(c => c.Sales.Sum(x => x.Car.PartCars.Sum(pc => pc.Part.Price)))
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = c.Sales.Sum(x => x.Car.PartCars.Sum(pc => pc.Part.Price))

                });

            var json = JsonConvert.SerializeObject(result, Config.jsonSettings);

            return json;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts. For the car get only make, model and traveled distance and for the parts get only name and price (formatted to 2nd digit after the decimal point). Export the list of cars and their parts to JSON in the format provided below.

            var result = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance,
                    parts = c.PartCars.Select(p => new ExportPartDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("f2")

                    })

                }).ToList();
            var exportObjects = new List<ExportCarPartsRootDto>();
            foreach (var item in result)
            {
                var exportObject = new ExportCarPartsRootDto
                {
                    car = new ExportCarDto
                    {
                        Make = item.Make,
                        Model = item.Model,
                        TravelledDistance = item.TravelledDistance

                    },
                    parts = item.parts

                };
                exportObjects.Add(exportObject);


            }

            var json = JsonConvert.SerializeObject(exportObjects, Formatting.Indented);

            return json;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            //Get all suppliers that do not import parts from abroad. Get their id, name and the number of parts they can offer to supply. Export the list of suppliers to JSON in the format provided below.

            var result = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(s => new
                {
                    s.Id,
                    s.Name,
                    PartsCount = s.Parts.Count


                });

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            //Get all cars from making Toyota and order them by model alphabetically and by traveled distance descending. Export the list of cars to JSON in the format provided below.

            var result = context.Cars
                .Where(x => x.Make.Equals("Toyota"))
                .OrderBy(c => c.Model)
                .ThenByDescending(d => d.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance

                });



            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;

        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            //Get all customers ordered by their birth date ascending. If two customers are born on the same date first print those who are not young drivers (e.g., print experienced drivers first). Export the list of customers to JSON in the format provided below.
            var result = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(ex => ex.IsYoungDriver)
                .Select(c => new
                {
                    c.Name,
                    BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                    c.IsYoungDriver

                });


            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = GenerateEntities<ImportSaleDto, Sale>(inputJson);
            //Where(x=>context.Cars.Any(y=>y.Id == x.CarId)).Where(x => context.Customers.Any(y => y.Id == x.CustomerId));

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";

        }

        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = GenerateEntities<ImportSupplierDto, Supplier>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";

        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {

            var parts = GenerateEntities<ImportPartDto, Part>(inputJson).Where(r => context.Suppliers.Select(x => x.Id).Contains(r.SupplierId));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {

            var carsDto = JsonConvert.DeserializeObject<ICollection<ImportCarDto>>(inputJson);
            var cars = new List<Car>();
            foreach (var car in carsDto)
            {
                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartCars.Distinct())
                {
                    currCar.PartCars.Add(new PartCar
                    {
                        PartId = partId

                    });
                }

                cars.Add(currCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {

            var customers = GenerateEntities<ImportCustomerDto, Customer>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }


        public static ICollection<TDestination> GenerateEntities<TSource, TDestination>(string inputJson)
        {
            var TDto = JsonConvert.DeserializeObject<ICollection<TSource>>(inputJson);
            var TModel = Config.mapper.Map<ICollection<TDestination>>(TDto);

            return TModel;
        }
    }
}