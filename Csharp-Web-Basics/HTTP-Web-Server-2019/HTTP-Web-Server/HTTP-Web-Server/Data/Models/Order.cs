using HTTP_Web_Server.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public Status Status { get; set; }

        public Product Product { get; set; } = null!;

        public int Quantity { get; set; }

        public User Cashier { get; set; } = null!;

        public Receipt Receipt { get; set; } = null!;

        public string? ReceiptId { get; set; } 
    }
}
