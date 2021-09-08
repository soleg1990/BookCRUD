using Database.EntityConfigurations;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Database
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(BookConfiguration).Assembly);

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            builder.Entity<Book>().HasData(
                            new Book { Id = 1, Title = "Миф о Сизифе", CreationDate = new DateTime(1970, 12, 7) },
                            new Book { Id = 2, Title = "Орлеанская девственница", CreationDate = new DateTime(1690, 7, 12) },
                            new Book { Id = 3, Title = "Повелитель мух", CreationDate = new DateTime(1954, 9, 17) }
                            );
        }
    }
}
