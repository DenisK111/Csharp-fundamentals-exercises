using HTTP_Web_Server.Data;
using HTTP_Web_Server.Data.Enums;
using HTTP_Web_Server.Data.Models;
using HTTP_Web_Server.ViewModels;
using MVCFramework;
using MVCFramework.Attributes;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HTTP_Web_Server.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context )
        {
            this.context = context;
        }

        public IHttpResponse All()
        {
            var result = context.Products.Select(x => new ProductsViewModel
            {
                Name = x.Name,
                Barcode = x.Barcode,
                Picture = x.PictureUrl,
                Price = x.Price

            })
                .ToList();
            return View(result);
        }

        public IHttpResponse Create()
        {

            if (!IsUserSignedIn() || this.Request!.Session.GetValue(UserIdSessionName)!.Value.userRole != (int)IdentityRole.Admin )
            {
                return Redirect("/Users/login");
            }

            

            return View();
        }
        [HttpPost]

        public IHttpResponse Create(ProductsInputViewModel model)
        {

            if (!IsUserSignedIn() || this.Request!.Session.GetValue(UserIdSessionName)!.Value.userRole != (int)IdentityRole.Admin)
            {
                return Redirect("/Users/login");
            }

            var product = new Product
            {
                Name = model.Name,
                PictureUrl = HttpUtility.UrlDecode(model.Picture),
                Price = model.Price,
                Barcode = model.Barcode
            };

            context.Add(product);
            context.SaveChanges();


            return All();
        }

        [HttpPost]
        public IHttpResponse Order(string product, int quantity)
        {
            var user = context.Users
                .Where(x => this.Request!.Session.GetValue(UserIdSessionName)!.Value.userId == x.UserName)
                .First();
            var chosenProduct = context.Products.Where(x => x.Barcode == product)
                .First();
            var order = new Order()
            {
                Cashier = user,
                Product = chosenProduct,
                Quantity = quantity,
                Status = Status.Active
            };

            context.Add(order);
            context.SaveChanges();

            return Redirect("/"); 
        }


     

    }
}
