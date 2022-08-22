using BasicWebServer.Server.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Data.Models
{
    public class User : UserIdentity
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserTrips = new HashSet<UserTrip>();
        }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }

        
        [Required]
        public string Password { get; set; } 

        public ICollection<UserTrip> UserTrips { get; set; }

        /*⦁	Has a Username – a string with min length 5 and max length 20 (required)
        ⦁	Has an Email - a string (required)
        ⦁	Has a Password – a string with min length 6 and max length 20  - hashed in the database (required)
        ⦁	Has UserTrips collection – a UserTrip type
        */
    }
}
