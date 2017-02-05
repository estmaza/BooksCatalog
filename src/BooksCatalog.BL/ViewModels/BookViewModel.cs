using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksCatalog.BL.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            AuthorId = new List<int>();
            Items = new Dictionary<int, string>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public string Date { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Number between 1 and 10")]
        public int Rating { get; set; }

        [Required]
        public int Pages { get; set; }

        public List<int> AuthorId { get; set; }
        public Dictionary<int,string> Items { get; set; }
    }
}
