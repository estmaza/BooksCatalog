using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksCatalog.BL.ViewModels
{
    public class TableViewModel
    {
        public int BookId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<int, string> Authors { get; set; }

        public int Raiting { get; set; }

        public int Pages { get; set; }
    }
}
