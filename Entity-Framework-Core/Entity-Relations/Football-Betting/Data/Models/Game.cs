using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_FootballBetting.Data.Models
{
    public class Game
    {
        public Game()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
            Bets = new HashSet<Bet>();
        }

        [Key]
        public int GameId { get; set; }

        [Required]
        [ForeignKey(nameof(HomeTeam))]
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        [Required]
        [ForeignKey(nameof(AwayTeam))]
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        [Required]
        [Column(TypeName ="Tinyint")]
        public int HomeTeamGoals { get; set; }
        [Required]
        [Column(TypeName = "Tinyint")]
        public int AwayTeamGoals { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal HomeTeamBetRate { get; set; }

        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal AwayTeamBetRate { get; set; }
        [Required]
        [Column(TypeName = "decimal(4,2)")]
        public decimal DrawBetRate { get; set; }
        [Required]
        [MaxLength(10)]
        public string Result { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }

        


    }
}