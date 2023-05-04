using System.Linq;
using EcommerceSiteApi.Model;
using EcommerceSiteApi.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceSiteApi.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly EcommerceDbContext _ecommerceDbContext;
        public ProductsController(EcommerceDbContext ecommerceDbContext)
        {
            _ecommerceDbContext = ecommerceDbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var products = _ecommerceDbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductInputModel productInputModel)
        {
            if (productInputModel == null)
            {
                return BadRequest();
            }

            var product = new Product(productInputModel.Description, productInputModel.Price);
            _ecommerceDbContext.Products.Add(product);
            _ecommerceDbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromBody] ProductInputModel productInputModel, int id)
        {
            if (productInputModel == null)
            {
                return BadRequest();
            }

            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            product.Description = productInputModel.Description;
            product.Price = productInputModel.Price;

            if (product == null)
            {
                return NotFound();
            }

            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _ecommerceDbContext.Products.SingleOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            _ecommerceDbContext.Products.Remove(product);
            _ecommerceDbContext.SaveChanges();

            return NoContent();
        }
    }
}