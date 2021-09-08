using Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Database.Repositories.Contracts
{
    public interface IBookRepository
    {
        Task Delete(Book book);
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(long id);
        Task Insert(Book book);
        Task Update(Book book);
    }
}
