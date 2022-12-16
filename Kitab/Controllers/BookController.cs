using Kitab.Data;
using Kitab.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kitab.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            /*var allbooks = _context.Books.Include(n => n.Publisher).OrderBy(n => n.Title).ToList();*/
            //LINQ - Table join garne ani chahiteko 
            //ViewBag
            var allBooks = await _service.GetAllAsync();
            return View(allBooks);
        }
    }
}
