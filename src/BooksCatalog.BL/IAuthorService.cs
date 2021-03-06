﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.BL.ViewModels;

namespace BooksCatalog.BL
{
    public interface IAuthorService
    {
        Task<AuthorViewModel> Get(int id);
        IEnumerable<AuthorViewModel> GetAll();
        AuthorViewModel Save(AuthorViewModel author);
        void Delete(int id);
    }
}
