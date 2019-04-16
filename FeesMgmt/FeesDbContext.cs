using FeesMgmt.Models;
using Microsoft.EntityFrameworkCore;

namespace FeesMgmt
{
    public class FeesDbContext : DbContext
    {
        public const string ConnectionString = "Server=localhost;Database=feesDb;UserId=root;Password=computer;";
        public DbSet<CustomerRegistered> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
        }
    }
}
