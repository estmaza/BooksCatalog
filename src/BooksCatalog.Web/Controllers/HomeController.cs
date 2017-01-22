using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksCatalog.BL;

namespace BooksCatalog.Web.Controllers
{
    public class HomeController : Controller
    {
        protected readonly IBookService _bookService;

        public HomeController(IBookService bookSevece)
        {
            _bookService = bookSevece;
        }

        public IActionResult Index()
        {
            var model = _bookService.GetTable();
            return View(model);
        }
    }
}
