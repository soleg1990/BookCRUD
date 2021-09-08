using Core.DTOs;
using Core.Exceptions;
using Core.Services.Contracts;
using Database.Models;
using Database.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger; //TODO: логгирование

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<long> Add(BookDto book)
        {
            var entity = book.ToEntity();
            await _bookRepository.Insert(entity);
            return entity.Id;
        }

        public async Task Update(BookDto book)
        {
            if (!book.Id.HasValue)
            {
                throw new ArgumentNullException(nameof(book.Id));
            }

            await FindOrThrow(book.Id.Value);
            await _bookRepository.Update(book.ToEntity());
        }

        public async Task<BookDto> Get(long id)
        {
            var book = await _bookRepository.Get(id);
            return book.ToDto();
        }

        public async Task<IEnumerable<BookDto>> Get()
        {
            var books = await _bookRepository.Get();
            return books.ToDtos();
        }

        public async Task Delete(long id)
        {
            var book = await FindOrThrow(id);
            await _bookRepository.Delete(book);
        }

        private async Task<Book> FindOrThrow(long id)
        {
            var book = await _bookRepository.
                Get(id);

            //TODO: возвращать ErrorResult вместо проброса исключения
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }

            return book;
        }
    }
}
