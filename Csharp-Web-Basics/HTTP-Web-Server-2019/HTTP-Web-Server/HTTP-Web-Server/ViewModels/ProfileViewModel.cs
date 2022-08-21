using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Web_Server.ViewModels
{
    public class ProfileViewModel
    {
        public string Id { get; set; } = null!;
        public string Total { get; set; } 

        public string IssuedOn { get; set; } = null!;
        public string Cashier { get; set; } = null!;
    }
}
