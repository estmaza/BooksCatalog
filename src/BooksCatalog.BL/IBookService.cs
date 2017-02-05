using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Data.Entity;
using BooksCatalog.BL.ViewModels;

namespace BooksCatalog.BL
{
    public interface IBookService
    {
        IEnumerable<TableViewModel> GetTable();
        Task<BookViewModel> Get(int id);
        BookViewModel Save(BookViewModel book);
        void Delete(int id);
    }
}
