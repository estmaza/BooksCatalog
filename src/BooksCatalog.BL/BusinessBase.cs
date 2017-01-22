using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksCatalog.Data;

namespace BooksCatalog.BL
{
    public class BusinessBase
    {
        protected readonly ApplicationDBContext _dbContext;

        public BusinessBase(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
