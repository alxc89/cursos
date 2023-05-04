using System.Collections.Generic;
using System.Threading.Tasks;
using BookApi.Model;

namespace BookApi.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(int Id);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int Id);
    }
}