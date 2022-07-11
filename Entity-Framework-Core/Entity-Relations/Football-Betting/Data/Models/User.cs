using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {

        public User()
        {
            Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        [MaxLength(40)]
        public string Username { get; set; }


        [MaxLength(100)]
        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "decimal(15,2)")]
        public decimal Balance { get; set; }

        public ICollection<Bet> Bets { get; set; }
    }
}