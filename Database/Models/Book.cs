using System;

namespace Database.Models
{
    public class Book
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
