using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCFramework
{
    public class IdentityUser<T>
    {

        public T Id { get; set; } = default(T)!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public IdentityRole Role { get; set; }
    }
}
