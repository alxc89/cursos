using Microsoft.AspNetCore.Mvc;
using store.Models;
using store.Repositories;

namespace store.Controllers
{
    [Route("v1/api")]
    public class HomeController : Controller
    {
        private readonly ProductRepository _repository;
        public HomeController(ProductRepository repository)
        {
            _repository = repository;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<Product>? Get()
        {
            return _repository.Get();
        }
        [HttpPost]
        public string Post([FromBody]Product product)
        {
            _repository.Create(product);
            return "Produto Salvo com Sucesso!";
        }
    }
}