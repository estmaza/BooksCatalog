using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.BL.ViewModels;
using BooksCatalog.Data;
using BooksCatalog.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BooksCatalog.BL
{
    public class BookService : IBookService
    {
        private readonly ApplicationDBContext _dbContext;

        public BookService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<TableViewModel> GetTable()
        {
            var query = _dbContext.Books
                .Include(p => p.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .ToList();

            var table = new List<TableViewModel>();

            foreach (var q in query)
            {
                var auth = new Dictionary<int, string>();

                foreach (var hui in q.BookAuthors)
                    auth.Add(hui.AuthorId, $"{hui.Author.FirstName} {hui.Author.LastName}");

                table.Add(new TableViewModel
                {
                    BookId = q.Id,
                    Name = q.Name,
                    Date = q.Date,
                    Raiting = q.Rating,
                    Pages = q.Pages,
                    Authors = auth            
                });
            }
            return table;
        }

        public async Task<BookViewModel> Get(int id)
        {
            if (id == 0)
                return new BookViewModel();
            var model = await _dbContext.Books.FindAsync(id);
            var authors = _dbContext.BookAuthors.Where(p => p.Book.Equals(model));

            var entity = ToViewModel(model);
            foreach (var a in authors)
                entity.AuthorId.Add(a.AuthorId);

            return entity;
        }

        public BookViewModel Save(BookViewModel book)
        {
            if (book.Id == 0)
            {
                var entity = ToEntity(book);
                _dbContext.Books.Add(entity);

                foreach (var a in book.AuthorId)
                    _dbContext.BookAuthors.Add(new BookAuthor { Book = entity, AuthorId = a });
            }
            else
            {
                var entity = _dbContext.Books.Include("BookAuthors").First(p => p.Id.Equals(book.Id));
                //var entity = _dbContext.Books.Find(book.Id)

                entity.Name = book.Name;
                entity.Date = book.Date;
                entity.Pages = book.Pages;
                entity.Rating = book.Rating;

                // Update authors
                var existedIds = entity.BookAuthors.Select(p => p.AuthorId);

                var toAdd = book.AuthorId.Except(existedIds);
                foreach (var a in toAdd)
                    _dbContext.BookAuthors.Add(new BookAuthor { Book = entity, AuthorId = a });

                var toRemove = existedIds.Except(book.AuthorId);
                foreach (var a in toRemove)
                    _dbContext.BookAuthors.Remove(entity.BookAuthors.Find(p => p.AuthorId == a));                
            }
            _dbContext.SaveChanges();

            var savedBook = _dbContext.Books.Last();
            return ToViewModel(savedBook);
        }

        public void Delete(int id)
        {
            var book = _dbContext.Find<Book>(id);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
            }
        }

        private BookViewModel ToViewModel(Book book)
        {
            var model = new BookViewModel
            {
                Id = book.Id,
                Name = book.Name,
                Date = book.Date,
                Pages = book.Pages,
                Rating = book.Rating
            };
            return model;
        }

        private Book ToEntity(BookViewModel book)
        {
            var model = new Book
            {
                Id = book.Id,
                Name = book.Name,
                Date = book.Date,
                Pages = book.Pages,
                Rating = book.Rating
            };
            return model;
        }
    }
}
