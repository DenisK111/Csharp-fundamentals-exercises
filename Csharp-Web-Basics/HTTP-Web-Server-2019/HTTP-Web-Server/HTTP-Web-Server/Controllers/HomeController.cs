using HTTP_Web_Server.Data;
using HTTP_Web_Server.Data.Enums;
using HTTP_Web_Server.ViewModels;
using MVCFramework;
using MVCFramework.Attributes;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;

        public HomeController(ApplicationDbContext context) 
        {
            this.context = context;
        }
        [HttpGet("/")]
        public IHttpResponse Index()
        {

            if (!IsUserSignedIn())
            {
                return View(new OrdersTotalViewModel());
            }

            var user = GetUserId();

            var orderViewModel = context.Orders.Where(y => y.Cashier.UserName == user && y.Status == Status.Active)
            .Select(x => new OrdersViewModel
            {
                Name = x.Product.Name,
                Quantity = x.Quantity,
                Price = x.Product.Price
            })
            .ToList();

            var totalViewModel = new OrdersTotalViewModel() { Products = orderViewModel };

            if (totalViewModel == null)
            {
                return this.View(new OrdersTotalViewModel());
            }

            return this.View(totalViewModel);
        }



        [HttpGet("/Home/Index")]
        public IHttpResponse IndexRedirect()
        {

            return Redirect("/");
        }
    }
}
