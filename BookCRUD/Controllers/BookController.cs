using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookCRUD.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiVersion("1")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //TODO: таблица авторов и M:N
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Добавить новую книгу
        /// </summary>
        /// <returns>Id новой книги</returns>
        [HttpPost]
        public Task<long> Add([FromBody]BookDto book)
        {
            return _bookService.Add(book);
        }

        /// <summary>
        /// Обновить книгу
        /// </summary>
        [HttpPut]
        public Task Update([FromBody]BookDto book)
        {
            return _bookService.Update(book);
        }

        /// <summary>
        /// Удалить книгу
        /// </summary>
        /// <param name="id">Id книги</param>
        [HttpDelete]
        [Route("{id:long:min(1)}")]
        public Task Delete([FromRoute]long id)
        {
            return _bookService.Delete(id);
        }

        //TODO: pagination and filtration
        /// <summary>
        /// Получить список книг
        /// </summary>
        [HttpGet]
        [Route("Books")]
        public Task<IEnumerable<BookDto>> Get()
        {
            return _bookService.Get();
        }

        /// <summary>
        /// Получить книгу по Id
        /// </summary>
        [HttpGet]
        [Route("{id:long:min(1)}")]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public Task<BookDto> Get([FromRoute]long id)
        {
            return _bookService.Get(id);
        }
    }
}
