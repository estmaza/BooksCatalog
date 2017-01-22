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


            //var table = query
            //    .Select(p => new TableViewModel
            //    {
            //        BookId = p.Id,
            //        Name = p.Name,
            //        Date = p.Date,
            //        Raiting = p.Rating,
            //        Pages = p.Pages,
            //        Authors = GetAuthors(p.BookAuthors)
            //    });
            return table;
        }

        //public Dictionary<int, string> GetAuthors(int id)
        //{
        //    var authors = new Dictionary<int, string>();

        //    var res = _dbContext.BookAuthors.Include(p => p.Author);

        //    var r = res.Where(p => p.BookId == id);

        //    foreach (var ba in baList)
        //        authors.Add(ba.Author.Id, $"{ba.Author.FirstName} {ba.Author.LastName}");

        //    return authors;
        //}


        //public Dictionary<int,string> GetAuthors(IEnumerable<BookAuthor> baList)
        //{
        //    var authors = new Dictionary<int, string>();

        //    foreach (var ba in baList)
        //        authors.Add(ba.Author.Id, $"{ba.Author.FirstName} {ba.Author.LastName}");

        //    return authors;
        //}

        public Author GetAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Author author)
        {
            throw new NotImplementedException();
        }

        public void Save(Book book)
        {
            throw new NotImplementedException();
        }

        public void DeleteAuthor(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
