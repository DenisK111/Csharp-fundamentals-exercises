using MVCFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.Data.Models
{
    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Orders = new HashSet<Order>();
            this.Receipts = new HashSet<Receipt>();
        }

        public ICollection<Order> Orders { get; set; }
        
        public ICollection<Receipt> Receipts { get; set; }


    }
}
