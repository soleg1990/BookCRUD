using System;

namespace Core.DTOs
{
    public class BookDto
    {
        public long? Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
