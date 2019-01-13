using Microsoft.EntityFrameworkCore;
using TestShopServiceRest.Models;

namespace TestShopServiceRest.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestShopDb;Trusted_Connection=True;");
        }
        //Add-Migration Initial
        //Remove-Migration
        //Update-Database
    }
}
