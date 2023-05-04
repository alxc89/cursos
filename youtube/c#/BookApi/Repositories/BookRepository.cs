using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories
{
    public class BookRepository : IBookRepository
    {
        public readonly BookContext _context;
        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<Book> Create(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(int id)
        {
            var bookDelete = await _context.Books.FindAsync(id);

            if (bookDelete == null)
            {
                return;
            }
            _context.Books.Remove(bookDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task Update(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}