using Database.Models;
using Database.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext bookContext)
        {
            _dbContext = bookContext;
        }

        public Task Insert(Book book)
        {
            _dbContext.Add(book);
            return _dbContext.SaveChangesAsync();
        }

        public Task Update(Book book)
        {
            _dbContext.Attach(book).State = EntityState.Modified;
            return _dbContext.SaveChangesAsync();
        }

        public Task<Book> Get(long id)
        {
            return _dbContext.Books.AsNoTracking()
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _dbContext.Books.AsNoTracking()
                .ToListAsync();
        }

        public Task Delete(Book book)
        {
            _dbContext.Remove(book);
            return _dbContext.SaveChangesAsync();
        }
    }
}
