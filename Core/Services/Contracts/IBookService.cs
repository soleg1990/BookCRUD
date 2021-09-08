using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services.Contracts
{
    public interface IBookService
    {
        Task<long> Add(BookDto book);
        Task Delete(long id);
        Task<IEnumerable<BookDto>> Get();
        Task<BookDto> Get(long id);
        Task Update(BookDto book);
    }
}
