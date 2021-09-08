using AutoMapper;
using Core.DTOs;
using Database.Models;
using System.Collections.Generic;

namespace Core
{
    public static class BookMapper
    {
        private static readonly IMapper _mapper;

        static BookMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;
                ConfigureBookMap(cfg);
            });

            _mapper = config.CreateMapper();
        }

        public static BookDto ToDto(this Book book)
        {
            return _mapper.Map<BookDto>(book);
        }

        public static IEnumerable<BookDto> ToDtos(this IEnumerable<Book> books)
        {
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public static Book ToEntity(this BookDto bookDto)
        {
            return _mapper.Map<Book>(bookDto);
        }

        private static void ConfigureBookMap(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Book, BookDto>();
            cfg.CreateMap<BookDto, Book>();
        }
    }
}
