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

        public void Save(AuthorViewModel author)
        {
            throw new NotImplementedException();
        }

        private AuthorViewModel ToViewModel(Author author)
        {
            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                BooksNum = 1000
            };
            return model;
        }
    }
}
