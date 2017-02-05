using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksCatalog.BL;
using BooksCatalog.BL.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksCatalog.Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _authorService.Get(id);
            return PartialView("_EditAuthorPartial", model);
        }

        [HttpPost]
        public IActionResult Save(AuthorViewModel author)
        {
            _authorService.Save(author);
            return Ok();
        }
    }
}
