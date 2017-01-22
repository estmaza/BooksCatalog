using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BooksCatalog.Data.Entity
{
    public class Author
    {
        public Author()
        {
            BookAuthors = new List<BookAuthor>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public List<BookAuthor> BookAuthors { get; set; }
    }
}
