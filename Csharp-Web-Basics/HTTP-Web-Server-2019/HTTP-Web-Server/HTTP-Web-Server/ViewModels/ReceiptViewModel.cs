using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.ViewModels
{
    public class ReceiptViewModel
    {
        public ReceiptViewModel()
        {
            this.Product = new List<(string name, int quantity, decimal price)>();
           
        }
        public ICollection<(string name, int quantity, decimal price)> Product { get; set; }
        public string Total => Product.Sum(x =>x.price).ToString("f2");

        public string IssuedOn { get; set; } = null!;

        public string Cashier { get; set; } = null!;

        public string Id { get; set; } = null!;

    }
}
