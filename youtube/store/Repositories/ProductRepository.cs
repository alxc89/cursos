using store.Data;
using store.Models;

namespace store.Repositories
{
    public class ProductRepository
    {
        private readonly StoreDataContext _context;
        public ProductRepository(StoreDataContext context)
        {
            _context = context;
        }
        public IEnumerable<Product>? Get()
        {
            return _context.Products;
        }

        public void Create(Product product)
        {
            _context.Products?.Add(product);
            _context.SaveChanges();
        }
    }
}