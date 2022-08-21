using HTTP_Web_Server.Data;
using HTTP_Web_Server.Data.Enums;
using HTTP_Web_Server.Data.Models;
using MVCFramework;
using MVCFramework.Attributes;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrdersController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public IHttpResponse Cashout()
        {
            var user = GetUserId();
            var userEntity = context.Users.Where(x => x.UserName == user).First();
            var orders = context.Orders.Where(o => o.Cashier.UserName == user && o.Status == Status.Active).ToList();
            foreach (var order in orders)
            {
                order.Status = Status.Completed;
            }
            var receipt = new Receipt()
            {
                Cashier = userEntity,
                IssuedOn = DateTime.UtcNow,
                Orders = orders,
            };

            context.Add(receipt);
            context.SaveChanges();
            var id = receipt.Id;

            return this.Redirect($"/Receipts/Details?id={id}");
        }
    }
}
