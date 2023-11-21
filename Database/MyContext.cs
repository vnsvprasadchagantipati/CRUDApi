using CRUDApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Database
{
    public class MyContext : DbContext
    {
        public DbSet<User> Users { get; set; }  

        public DbSet<Item> Items { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= DESKTOP-30U1UJQ\\SQLEXPRESS01; Initial Catalog=Item;User Id=Varaprasad;Password=12345;TrustServerCertificate=true");
        }

    }
}
