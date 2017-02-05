using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Data.Entity;
using BooksCatalog.BL.ViewModels;
using BooksCatalog.Data;

namespace BooksCatalog.BL
{
    public class AuthorService : BusinessBase, IAuthorService
    {
        public AuthorService(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthorViewModel> Get(int id)
        {
            if (id == 0)
                return new AuthorViewModel();
            var author = await _dbContext.Authors.FindAsync(id);
            return ToViewModel(author);
        }

        public IEnumerable<AuthorViewModel> GetAll()
        {
            return _dbContext.Authors.Select(p => ToViewModel(p));
        }        

        public AuthorViewModel Save(AuthorViewModel author)
        {
            if (author.Id == 0)
                _dbContext.Authors.Add(ToEntity(author));
            else
            {
                var model = _dbContext.Authors.Find(author.Id);

                model.FirstName = author.FirstName;
                model.LastName = author.LastName;
            }
            _dbContext.SaveChanges();

            if (author.Id == 0)
                return ToViewModel(_dbContext.Authors.Last());
            return author;
        }

        private AuthorViewModel ToViewModel(Author author)
        {
            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BooksNum = 1000 // TODO Author: written books count
            };
            return model;
        }

        private Author ToEntity(AuthorViewModel author)
        {
            var model = new Author
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return model;
        }        
    }
}
