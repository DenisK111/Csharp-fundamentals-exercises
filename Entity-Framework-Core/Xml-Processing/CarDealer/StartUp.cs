using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            var db = new CarDealerContext();
            // db.Database.EnsureDeleted();
            // db.Database.EnsureCreated();

            using (db)
            {
                // //Problem1
                // var xmlString1 = File.ReadAllText("../../../Datasets/suppliers.xml");
                //  Console.WriteLine(ImportSuppliers(db, xmlString1));
                // //Problem2
                //  var xmlString2 = File.ReadAllText("../../../Datasets/parts.xml");
                // Console.WriteLine(ImportParts(db, xmlString2));
                // //Problem3
                //  var xmlString3 = File.ReadAllText("../../../Datasets/cars.xml");
                // Console.WriteLine(ImportCars(db, xmlString3));
                // //Problem4
                // var xmlString4 = File.ReadAllText("../../../Datasets/customers.xml");
                // Console.WriteLine(ImportCustomers(db,xmlString4));
                // //Problem5
                // var xmlString5 = File.ReadAllText("../../../Datasets/sales.xml");
                // Console.WriteLine(ImportSales(db, xmlString5));
                //Console.WriteLine(GetCarsWithDistance(db));
                //Console.WriteLine(GetCarsFromMakeBmw(db));
                //Console.WriteLine(GetCarsWithTheirListOfParts(db));
                //Console.WriteLine(GetTotalSalesByCustomer(db));
                Console.WriteLine(GetSalesWithAppliedDiscount(db));
            }

        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            //Get all sales with information about the car, customer and price of the sale with and without discount.

            var result = context.Sales
               .Select(s =>
                   new Dto.Export.salesSale
                   {
                       car = new Dto.Export.salesSaleCar
                       {
                           make = s.Car.Make,
                           model = s.Car.Model,
                         travelleddistance = s.Car.TravelledDistance
                       },
                       customername = s.Customer.Name,
                       discount = s.Discount,
                       price = s.Car.PartCars.Sum(x => x.Part.Price),
                       pricewithdiscount = (s.Car.PartCars.Sum(x => x.Part.Price) * (1 - (s.Discount / 100)))


                   })
               .ToArray();

            return Serialize<Dto.Export.salesSale[]>("sales", result);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {


            var result = context.Customers
                .Where(c => c.Sales.Any())
                                .Select(x => new Dto.Export.customersCustomer
                                {
                                    fullname = x.Name,
                                    boughtcars = x.Sales.Count(),
                                    spentmoney = x.Sales.SelectMany(c => c.Car.PartCars
                    , (c, y) => y.Part.Price).Sum()
                                })
                                                .OrderByDescending(x => x.spentmoney)


                .ToArray();

            return Serialize<Dto.Export.customersCustomer[]>("customers", result);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            //Get all cars along with their list of parts. For the car get only make, model and traveled distance and for the parts get only name and price and sort all parts by price (descending). Sort all cars by traveled distance (descending) then by the model (ascending). Select top 5 records.


            var result = context.Cars
                .Select(x => new Dto.Export3.carsCar
                {
                    make = x.Make,
                    model = x.Model,
                    travelleddistance = x.TravelledDistance,
                    parts = x.PartCars.Select(y => new Dto.Export3.carsCarPart
                    {
                        name = y.Part.Name,
                        price = y.Part.Price

                    })
                    .OrderByDescending(z => z.price)
                    .ToArray()

                })
                .OrderByDescending(x => x.travelleddistance)
                .ThenBy(x => x.model)
                .Take(5)
                .ToArray();



            return Serialize<Dto.Export3.carsCar[]>("cars", result);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var result = context.Suppliers
                .Where(x => !x.IsImporter)
                .Select(x => new Dto.Export.suppliersSuplier
                {
                    id = x.Id,
                    name = x.Name,
                    partscount = x.Parts.Count()

                })
                .ToArray();

            return Serialize<Dto.Export.suppliersSuplier[]>("suppliers", result);

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var result = context.Cars
                .Where(td => td.TravelledDistance > 2000000)
                .Select(x => new Dto.Export.carsCar
                {

                    make = x.Make,
                    model = x.Model,
                    travelleddistance = x.TravelledDistance




                })
                .OrderBy(x => x.make)
                .ThenBy(x => x.model)
                .Take(10)
                .ToArray();


            return Serialize<Dto.Export.carsCar[]>("cars", result);
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var result = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new Dto.Export2.carsCar
                {
                    id = x.Id,
                    model = x.Model,
                    travelleddistance = x.TravelledDistance
                })
                .OrderBy(x => x.model)
                .ThenByDescending(x => x.travelleddistance)
                .ToArray();

            return Serialize<Dto.Export2.carsCar[]>("cars", result);
        }

        public static string Serialize<T>(string rootName, T obj)
        {

            var sb = new StringBuilder();
            var root = new XmlRootAttribute(rootName);
            var nmspc = new XmlSerializerNamespaces();
            nmspc.Add(string.Empty, string.Empty);
            var serialiser = new XmlSerializer(typeof(T), root);
            serialiser.Serialize(new StringWriter(sb), obj, nmspc);
            return sb.ToString().TrimEnd();
        }


        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {

            var customerDto = GenerateDTO<ImportedCustomersDto>("Customers", inputXml);
            var customers = Config.mapper.Map<ICollection<Customer>>(customerDto.Customer);
            context.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}";

        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var cars = context.Cars.Select(x => x.Id).ToList();
            var salesDto = GenerateDTO<ImportedSalesDto>("Sales", inputXml);
            var sales = Config.mapper.Map<ICollection<Sale>>(salesDto.Sale).Where(s => cars.Contains(s.CarId)).ToList();
            context.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count()}";

        }
        public static string ImportCars(CarDealerContext context, string inputXml)
        {


            var carsDto = GenerateDTO<ImportedCarsDto>("Cars", inputXml);
            var cars = carsDto.Car.Select(x => new
            {
                Make = x.make,
                Model = x.model,
                TravelledDistance = x.TraveledDistance,
                PartCarId = x.parts.Select(y => y.id)

            });
            var carList = new List<Car>();
            var partIds = context.Parts.Select(p => p.Id).ToList();
            foreach (var car in cars)
            {
                var currCar = new Car
                {
                    Make = car.Make,
                    Model = car.Model,
                    TravelledDistance = car.TravelledDistance
                };

                foreach (var partId in car.PartCarId.Distinct())
                {
                    if (!partIds.Contains(partId))
                    {
                        continue;
                    }

                    currCar.PartCars.Add(new PartCar
                    {
                        PartId = partId

                    });
                }

                carList.Add(currCar);
            }

            context.AddRange(carList);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}";
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            var suppliersDto = GenerateDTO<ImportedSuppliersDto>("Suppliers", inputXml);
            var suppliers = Config.mapper.Map<ICollection<Supplier>>(suppliersDto.Supplier);
            context.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var suppliers = context.Suppliers.Select(x => x.Id).ToList();
            var partsDto = GenerateDTO<ImportedPartsDto>("Parts", inputXml);
            var parts = Config.mapper.Map<ICollection<Part>>(partsDto.Part).Where(r => suppliers.Contains(r.SupplierId));
            context.AddRange(parts);
            context.SaveChanges();
            return $"Successfully imported {parts.Count()}";
        }

        public static TDest GenerateDTO<TDest>(string rootName, string path)
        {
            
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(TDest), root);


            using (StringReader reader = new StringReader(path))
            {
                return (TDest)serializer.Deserialize(reader);
            }
        }
    }
}