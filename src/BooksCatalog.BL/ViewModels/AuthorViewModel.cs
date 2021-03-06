﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BooksCatalog.BL.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "First Name")]        
        public string FirstName { get; set; }

        [Required]
        [StringLength(256)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Number of books")]
        public int BooksNum { get; set; }
    }
}
