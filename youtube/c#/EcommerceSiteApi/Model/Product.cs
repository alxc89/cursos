using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceSiteApi.Controllers
{
    public class Product
    {
        public Product(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}