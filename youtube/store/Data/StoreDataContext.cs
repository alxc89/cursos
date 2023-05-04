using Microsoft.EntityFrameworkCore;
using store.Data.Maps;
using store.Models;

namespace store.Data
{
    public class StoreDataContext : DbContext
    {
        public DbSet<Product>? Products {get; set;}
        public DbSet<Category>? Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("store");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductMap());
        }
    }
}
