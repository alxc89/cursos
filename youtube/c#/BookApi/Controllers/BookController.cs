using System.Collections.Generic;
using System.Threading.Tasks;
using BookApi.Model;
using BookApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            return await _bookRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var deleteBook = await _bookRepository.Get(id);

            if (deleteBook == null)
            {
                return NotFound();
            }
            await _bookRepository.Delete(deleteBook.Id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> PutBooks(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            await _bookRepository.Update(book);
            return await _bookRepository.Get(book.Id);
        }
    }
}