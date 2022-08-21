using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.ViewModels
{
    public class ProductsInputViewModel
    {
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string Barcode { get; set; } = null!;

        public string? Picture { get; set; }
    }
}
