namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {


        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Player> Players { get; set; } = null!;
        public DbSet<UserPlayer> UserPlayers { get; set; } = null!;





        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=FootballManager-Denislav_Kraev;User ID=sa;Password=Sql12345678");
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPlayer>().HasKey(x => new { x.PlayerId, x.UserId });
        }
    }
}
