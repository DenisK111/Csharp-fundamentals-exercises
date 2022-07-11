using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
        }
        [Key]
        public int TeamId{ get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        [Required]
        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        [Required]
        [Column(TypeName = "Varchar(255)")]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(5)]
        public string Initials { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Required]
        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }
        [InverseProperty("HomeTeam")]
        public virtual ICollection<Game> HomeGames { get; set; }
        [InverseProperty("AwayTeam")]
        public virtual ICollection<Game> AwayGames { get; set; }


    }
}
