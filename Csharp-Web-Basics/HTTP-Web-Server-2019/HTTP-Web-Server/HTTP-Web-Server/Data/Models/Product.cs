using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Data.Models
{
    public class Product
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
        }
        public string Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        [Column(TypeName = "char(12)")]
        public string Barcode { get; set; } = null!;

        public string? PictureUrl { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
