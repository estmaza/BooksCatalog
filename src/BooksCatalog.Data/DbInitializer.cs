using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BooksCatalog.Data.Entity;

namespace BooksCatalog.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Books.Any())
            {
                return;   // DB has been seeded
            }

            var books = new List<Book>
            {
                new Book {Name = "ASP.NET MVC", Pages = 282, Rating = 9, Date = new DateTime(2015, 9, 3) },
                new Book {Name = "ASP.NET MVD", Pages = 992, Rating = 8, Date = new DateTime(2016, 8, 4) },
                new Book {Name = "ASP.NET MVE", Pages = 768, Rating = 7, Date = new DateTime(2017, 7, 5) },
                new Book {Name = "ASP.NET MVF", Pages = 512, Rating = 6, Date = new DateTime(2018, 6, 6) }
            };

            foreach (var b in books)
                context.Books.Add(b);
            context.SaveChanges();

            var authors = new List<Author>
            {
                new Author {FirstName = "Vlad", LastName = "Mazur" },
                new Author {FirstName = "Name1", LastName = "Sname1" },
                new Author {FirstName = "Name2", LastName = "Sname2" }
            };

            foreach (var a in authors)
                context.Authors.Add(a);
            context.SaveChanges();

            var bookAuthors = new List<BookAuthor>
            {
                new BookAuthor { Book = books[0], Author = authors[0] },
                new BookAuthor { Book = books[0], Author = authors[1] },
                new BookAuthor { Book = books[0], Author = authors[2] },
                new BookAuthor { Book = books[1], Author = authors[1] },
                new BookAuthor { Book = books[1], Author = authors[2] },
                new BookAuthor { Book = books[2], Author = authors[2] }
            };

            foreach (var ba in bookAuthors)
                context.BookAuthors.Add(ba);
            context.SaveChanges();
        }
    }
}
