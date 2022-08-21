using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Data.Models
{
    public class Player
    {
        public Player()
        {
            this.UserPlayers = new HashSet<UserPlayer>();
        }

        public int Id { get; set; }

        [MaxLength(80)]
        public string FullName { get; set; } = null!;
        
        public string ImageUrl { get; set; } = null!;
        [MaxLength(20)]
        public string Position { get; set; } = null!;

        public byte Speed { get; set; }
        public byte Endurance { get; set; }
        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public ICollection<UserPlayer> UserPlayers { get; set; }

        /*⦁	Has Id – an int, Primary Key
        ⦁	Has FullName – a string (required); min. length: 5, max. length: 80
        ⦁	Has ImageUrl – a string (required)
        ⦁	Has Position – a string (required); min. length: 5, max. length: 20
        ⦁	Has Speed – a byte (required); cannot be negative or bigger than 10
        ⦁	Has Endurance – a byte (required); cannot be negative or bigger than 10
        ⦁	Has a Description – a string with max length 200 (required)
        ⦁	Has UserPlayers collection
        */
    }
}
