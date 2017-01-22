using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BooksCatalog.Data.Entity
{
    public class Book
    {
        public Book()
        {
            BookAuthors = new List<BookAuthor>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number between 1 and 10")]
        public int Rating { get; set; }

        [Required]
        public int Pages { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
