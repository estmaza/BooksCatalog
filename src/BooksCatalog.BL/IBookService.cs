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
        Book GetBook(int id);
        Author GetAuthor(int id);
        void Save(Book book);
        void Save(Author author);
        void DeleteBook(int id);
        void DeleteAuthor(int id);
    }
}
