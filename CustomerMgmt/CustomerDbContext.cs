using CustomerMgmt.Models;
using Microsoft.EntityFrameworkCore;
namespace CustomerMgmt
{
    public class CustomerDbContext : DbContext
    {
        public const string ConnectionString = "Server=localhost;Database=customerDb;UserId=root;Password=computer;";
        public DbSet<CustomerRegistered> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString);
        }
    }
}