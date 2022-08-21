using HTTP_Web_Server.Data;
using HTTP_Web_Server.Data.Models;
using HTTP_Web_Server.ViewModels;
using Microsoft.EntityFrameworkCore;
using MVCFramework;
using SIS.HTTP.Responses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext context;

        public ReceiptsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IHttpResponse Details(string id)
        {
            var result = context.Receipts
                .Include(p => p.Orders)
                .ThenInclude(o => o.Product)
                .Where(x => x.Id == id)
                .Select(r => new ReceiptViewModel
                {
                    Product = r.Orders.Select(p => GetTuple(p)
                   ).ToList(),
                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Cashier = r.Cashier.UserName,
                    Id = r.Id


                })
                .First();

            return this.View(result);

        }

        public IHttpResponse All()
        {
            var result = context.Receipts
                .Include(p => p.Orders)
                .ThenInclude(o => o.Product)
                                .Select(r => new ReceiptViewModel
                                {
                                    Product = r.Orders.Select(p => GetTuple(p)
                   ).ToList(),
                                    IssuedOn = r.IssuedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                                    Cashier = r.Cashier.UserName,
                                    Id = r.Id


                                })
                .ToList();

            return this.View(result);

        }

        private static (string name, int quantity, decimal price) GetTuple(Order p)
        {

            return (p.Product.Name, p.Quantity, p.Product.Price * p.Quantity);
        }
    }
}
