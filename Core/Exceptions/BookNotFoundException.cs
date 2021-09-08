using System;

namespace Core.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(long id) : base($"Book not found. Id: {id}") { }
    }
}
