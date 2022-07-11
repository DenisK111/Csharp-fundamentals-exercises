using P03_FootballBetting.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
   

        public FootballBettingContext( DbContextOptions options) : base(options)
        {
        }

        public FootballBettingContext()
        {
        }

        public DbSet<Bet> Bets { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=FootballBettingDB;User ID=sa;Password=Sql12345678");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(builder =>

            {
                builder.Property(p => p.IsInjured)
                .HasDefaultValue(false);
            });

            modelBuilder.Entity<PlayerStatistic>(builder =>
            {
                builder.HasKey(p => new {p.GameId, p.PlayerId});
                builder.Property(p => p.ScoredGoals).HasDefaultValue(0);
                builder.Property(p => p.Assists).HasDefaultValue(0);
            });
            modelBuilder.Entity<Bet>(builder =>
            {
                builder.Property(p => p.DateTime)
                    .HasDefaultValue(DateTime.Now);
            });
            modelBuilder.Entity<Game>(builder =>
            {
                builder.Property(p => p.DateTime)
                    .HasDefaultValue(DateTime.Now);

                builder.HasOne(x => x.HomeTeam)
               .WithMany(x => x.HomeGames).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.Restrict);


                builder.HasOne(x => x.AwayTeam)
                .WithMany(x => x.AwayGames).HasForeignKey(x => x.AwayTeamId).OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Team>(builder =>
            {
                builder.HasOne(x => x.PrimaryKitColor)
                .WithMany(x=>x.PrimaryKitTeams).HasForeignKey(x => x.PrimaryKitColorId).OnDelete(DeleteBehavior.Restrict);


                builder.HasOne(x => x.SecondaryKitColor)
                .WithMany(x=>x.SecondaryKitTeams).HasForeignKey(x => x.SecondaryKitColorId).OnDelete(DeleteBehavior.Restrict);
            });



        }
    }
}
