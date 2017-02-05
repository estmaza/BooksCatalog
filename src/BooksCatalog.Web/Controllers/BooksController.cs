using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksCatalog.BL;
using BooksCatalog.BL.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooksCatalog.Web.Controllers
{
    public class BooksController : Controller
    {
        protected readonly IBookService _bookService;
        protected readonly IAuthorService _authorService;

        public BooksController(IBookService bookSevece, IAuthorService authorService)
        {
            _bookService = bookSevece;
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            var model = _bookService.GetTable();
            return View(model);
        }

        public async Task<IActionResult> Get(int id)
        {
            var model = await _bookService.Get(id);

            var items = _authorService.GetAll();
            foreach (var i in items)
                model.Items.Add(i.Id, $"{i.FirstName} {i.LastName}");

            return PartialView("_EditBookPartial", model);
        }

        public async Task<IActionResult> Save(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                var model = _bookService.Save(book);
                return Json(model);
            }
            return BadRequest();
        }
    }
}
