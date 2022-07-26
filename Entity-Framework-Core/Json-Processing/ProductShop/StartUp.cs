using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.User;
using ProductShop.Models;
using AutoMapper;
using ProductShop.Common;
using ProductShop.DTOs.Product;
using ProductShop.DTOs.Category;
using ProductShop.DTOs.CategoryProduct;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (var db = new ProductShopContext())
            {

                //Problem1
                //var json = File.ReadAllText("../../../Datasets/users.json");
                //Console.WriteLine(ImportUsers(db, json) ); 
                //Problem2
                //var json = File.ReadAllText("../../../Datasets/products.json");
                //Console.WriteLine(ImportProducts(db,json)); 
                //Problem3
                // var json = File.ReadAllText("../../../Datasets/categories.json");
                // Console.WriteLine(ImportCategories(db, json));
                //Problem4
                //var json = File.ReadAllText("../../../Datasets/categories-products.json");
                //Console.WriteLine(ImportCategoryProducts(db, json));

                //Console.WriteLine(GetProductsInRange(db));
                //Console.WriteLine(GetSoldProducts(db));
                //Console.WriteLine(GetCategoriesByProductsCount(db));
               // Console.WriteLine(GetUsersWithProducts(db));
            }
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {

            var usersDto = JsonConvert.DeserializeObject<ICollection<ImportUserDto>>(inputJson);

            var users = GlobalConstants.mapper.Map<ICollection<User>>(usersDto);

            context.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {usersDto.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {


            var productsDto = JsonConvert.DeserializeObject<ICollection<ImportProductDto>>(inputJson);

            var products = GlobalConstants.mapper.Map<ICollection<Product>>(productsDto);

            context.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {productsDto.Count}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {

            var categories = GenerateEntities<ImportCategoryDto, Category>(inputJson).Where(x => x.Name != null);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";

        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = GenerateEntities<ImportCategoryProductDto, CategoryProduct>(inputJson);

            context.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count()}";

        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            //Get all products in a specified price range:  500 to 1000 (inclusive). Order them by price (from lowest to highest). Select only the product name, price and the full name of the seller. Export the result to JSON.

            var result = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new
                {
                    x.Name,
                    x.Price,
                    Seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .OrderBy(p => p.Price)
                .ToList();

            var json = JsonConvert.SerializeObject(result, GlobalConstants.jsonSettings);
            // File.WriteAllText("products-in-range.json",json);

            return json;

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var result = context.Categories
                .OrderByDescending(c=>c.CategoryProducts.Count())
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoryProducts.Count(),
                    AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price).ToString("f2")

                });

                /*
                 * Get all categories. Order them in descending order by the category's products count. For each category select its name, the number of products, the average price of those products (rounded to the second digit after the decimal separator) and the total revenue (total price sum and rounded to the second digit after the decimal separator) of those products (regardless if they have a buyer or not).*/


            var json = JsonConvert.SerializeObject(result, GlobalConstants.jsonSettings);
            return json;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold product with a buyer. Order them in descending order by the number of sold products with a buyer. Select only their first and last name, age and for each product - name and price. Ignore all null values.

            var result =  new ExportUsersInfoDto
                {

                    Users = context.Users
                .Where(u => u.ProductsSold.Any(z => z.Buyer != null))
                .OrderByDescending(up => up.ProductsSold.Count(d => d.Buyer != null))
                .Select(x=>new ExportUsersWithFullProductInfoDto
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        SoldProductsInfo = new ExportSoldProductsFullInfoDto
                        {
                            SoldProducts = x.ProductsSold.Where(b=>b.Buyer != null).Select(y=>new ExportSoldProductShortInfoDto
                            {
                                Name=y.Name,
                                Price = y.Price

                            }).ToArray()
                        }
                        
                    }).ToArray()
                };


            
               
               

            var json = JsonConvert.SerializeObject(result, GlobalConstants.jsonSettings);
            return json;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item with a buyer. Order them by the last name, then by the first name. Select the person's first and last name. For each of the sold products (products with buyers), select the product's name, price and the buyer's first and last name.


            var result = context.Users.Where(u => u.ProductsSold.Any(x=>x.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    SoldProducts = x.ProductsSold
                    .Where(y=>y.Buyer.FirstName != null || y.Buyer.LastName != null)
                    .Select(s => new
                    {
                        s.Name,
                        s.Price,
                        buyerFirstName = s.Buyer.FirstName,
                        buyerLastName = s.Buyer.LastName

                    })
                    
                    

                });

            var json = JsonConvert.SerializeObject(result, GlobalConstants.jsonSettings);
            return json;
        }

        public static ICollection<TDestination> GenerateEntities<TSource, TDestination>(string inputJson)
        {
            var TDto = JsonConvert.DeserializeObject<ICollection<TSource>>(inputJson);
            var TModel = GlobalConstants.mapper.Map<ICollection<TDestination>>(TDto);

            return TModel;
        }


    }
}