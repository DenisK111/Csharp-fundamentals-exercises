using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Client_Demo
{
    internal class TweetContext : DbContext
    {
        public TweetContext()
        {

        }

        public TweetContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<TweetModel> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=TweetDb;User ID=sa;Password=Sql12345678");
            }
        }
    }
}
