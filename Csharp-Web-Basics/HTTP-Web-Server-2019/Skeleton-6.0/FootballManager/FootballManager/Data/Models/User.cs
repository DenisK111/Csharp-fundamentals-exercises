using BasicWebServer.Server.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class User : UserIdentity
    {

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.UserPlayers = new HashSet<UserPlayer>();
        }
        [MaxLength(20)]
        public string Username { get; set; } = null!;

        [MaxLength(60)]
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public ICollection<UserPlayer> UserPlayers { get; set; }
        /*⦁	Has an Id – a string, Primary Key
        ⦁	Has a Username – a string with min length 5 and max length 20 (required)
        ⦁	Has an Email – a string with min length 10 and max length 60 (required)
        ⦁	Has a Password – a string with min length 5 and max length 20 (before hashed)  - no max length required for a hashed password in the database (required)
        ⦁	Has UserPlayers collection
        */
    }
}
