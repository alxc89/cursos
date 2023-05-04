using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcommerceSiteApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace EcommerceSiteApi.Persistence
{
    public class EcommerceDbContext : DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options)
        {
           Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }
    }
}