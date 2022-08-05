using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    internal class SalesContext : DbContext
    {

        public SalesContext()
        {

        }

        public SalesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=Sales;User ID=sa;Password=Sql12345678");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(options =>
            {
                options.Property(x => x.Email).IsUnicode(false);
            });

            modelBuilder.Entity<Product>(options =>
            {

                options.Property(p => p.Description).HasDefaultValue("No description");
            });

            modelBuilder.Entity<Sale>(options =>
            {

                options.Property(p => p.Date).HasDefaultValueSql("GetDate()");
            });
            
        }
    }
}
