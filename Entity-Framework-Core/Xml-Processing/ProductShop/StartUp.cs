using ProductShop.Data;
using System.IO;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProductShop.Models;
using System.Collections.Generic;
using System.Linq;
using ProductShop.Dto.Imported;
using ProductShop.Dto.Exported;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ProductShopContext();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();


            using (db)
            {
                ////Problem1
                // var xmlString1 = File.ReadAllText("../../../Datasets/users.xml");
                // Console.WriteLine(ImportUsers(db, xmlString1));
                // //Problem2
                // var xmlString2 = File.ReadAllText("../../../Datasets/products.xml");
                // Console.WriteLine(ImportProducts(db, xmlString2));
                ////Problem3
                //var xmlString3 = File.ReadAllText("../../../Datasets/categories.xml");
                //Console.WriteLine(ImportCategories(db, xmlString3));
                ////Problem4
                //var xmlString4 = File.ReadAllText("../../../Datasets/categories-products.xml");
                //Console.WriteLine(ImportCategoryProducts(db, xmlString4));
                //Console.WriteLine(GetProductsInRange(db));
                //Console.WriteLine(GetSoldProducts(db));
                Console.WriteLine(GetCategoriesByProductsCount(db));
                //Console.WriteLine(GetUsersWithProducts(db));


            }
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var result = context.Products
               .Where(x => x.Price >= 500 && x.Price <= 1000)
               .Select(x => new Exported5
                   {
                   Name = x.Name,
                   Price = x.Price,
                   Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName }
               )
               .OrderBy(p => p.Price)
               .Take(10)
               .ToArray();

            var products = new ProductDto { Products = result };
            return Serialize<ProductDto>("Products", products);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var result = context.Users.Where(u => u.ProductsSold.Any(x => x.Buyer != null))
               .OrderBy(x => x.LastName)
               .ThenBy(x => x.FirstName)
               .Select(x => new ProductShop.Dto.Exported.UsersUser
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   soldProducts = x.ProductsSold

                   .Select(s => new UsersUserProduct
                   {
                       name = s.Name,
                       price = s.Price,


                   })
                   .ToArray()



               })
               .Take(5)
               .ToArray();
            
        

           
            return Serialize<Dto.Exported.UsersUser[]>("Users", result);

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {

            //TODO CHeck
            var result = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count())
                .ThenBy(x=>x.CategoryProducts.Sum(cp => cp.Product.Price))
                .Select(c => new Dto.Exported.CategoriesCategory
                {
                    
                    name = c.Name,
                    count = c.CategoryProducts.Count(),
                    averagePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)

                })
                .ToArray();

            return Serialize<Dto.Exported.CategoriesCategory[]>("Categories", result);
        }


        public static string GetUsersWithProducts(ProductShopContext context)
        {

            //Select users who have at least 1 sold product. Order them by the number of sold products (from highest to lowest). Select only their first and last name, age, count of sold products and for each product - name and price sorted by price (descending). Take top 10 records.
            var result = new Dto.Exported.D.ExportProductsUsersDto
            {
                count = context.Users.Count(x=>x.ProductsSold.Any()),
                users = context.Users
                .Include(u=>u.ProductsSold)                
                .ToArray()
               .Where(u => u.ProductsSold.Any())
               .OrderByDescending(up => up.ProductsSold.Count())
               .Select(x => new Dto.Exported.D.UsersUser
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   age = x.Age,
                   SoldProducts = new Dto.Exported.D.UsersUserSoldProducts
                   {
                       count = x.ProductsSold.Count(),
                       products =  x.ProductsSold.Select(y=> new Dto.Exported.D.UsersUserSoldProductsProduct{

                           name = y.Name,
                           price = y.Price

                       })
                       .OrderByDescending(p=>p.price)
                       .ToArray()
                   }

               })
               .Take(10)
               .ToArray()
                };


            return Serialize<Dto.Exported.D.ExportProductsUsersDto>("Users", result); 
        }

        public static string Serialize<T>(string rootName,T obj)
        {

            var sb = new StringBuilder();
            var root = new XmlRootAttribute(rootName);
            var nmspc = new XmlSerializerNamespaces();
            nmspc.Add(string.Empty, string.Empty);
            var serialiser = new XmlSerializer(typeof(T), root);
            serialiser.Serialize(new StringWriter(sb), obj, nmspc);
            return sb.ToString().TrimEnd();
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var categoriesDto = GenerateDTO<ImportCategoriesDto>("Categories", inputXml, "Categories.xml");
            var categories = Config.mapper.Map<ICollection<Category>>(categoriesDto.Category).Where(x => x.Name != null);
            context.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count()}";

            
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var categoryProductsDto = GenerateDTO<ImportCategoryProductDto>("CategoryProducts", inputXml, "Categories-Products.xml");

            var categoriesIds = context.Categories
                .Select(x => x.Id)
                .ToList();
            var productsIds = context.Products
                .Select(x => x.Id)
                .ToList();

            var categoryProducts = Config.mapper.Map<ICollection<CategoryProduct>>(categoryProductsDto.CategoryProduct)
                .Where(x=> categoriesIds.Any(y=>y == x.CategoryId) && productsIds.Any(y=>y == x.ProductId));
            context.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Count()}";
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var usersDto = GenerateDTO<ImportUsersDto>("Users", inputXml,"Users.xml");
            var users = Config.mapper.Map<ICollection<User>>(usersDto.User);
            context.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var usersDto = GenerateDTO<ImportProductsDto>("Products", inputXml,"Products.xml");
            var products = Config.mapper.Map<ICollection<Product>>(usersDto.Product);
            context.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";

        }

        public static TDest GenerateDTO<TDest>(string rootName, string path,string pathToWrite)
        {
            File.WriteAllText(pathToWrite, path);
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(TDest), root);


            using (StreamReader reader = new StreamReader(pathToWrite))
            {
                return (TDest)serializer.Deserialize(reader);
            }
        }
    }
}