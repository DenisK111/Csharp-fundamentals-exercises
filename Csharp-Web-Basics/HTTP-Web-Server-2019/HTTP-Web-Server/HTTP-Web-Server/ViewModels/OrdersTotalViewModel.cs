using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.ViewModels
{
    public class OrdersTotalViewModel
    {

       public ICollection<OrdersViewModel> Products { get; set; } = null!;
        public string Total => Products.Sum(x => x.Quantity * x.Price).ToString("f2");
    }
}
