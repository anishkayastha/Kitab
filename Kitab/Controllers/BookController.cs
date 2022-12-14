using Kitab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Kitab.Controllers
{
    public class BookController : Controller
    {
        private readonly KitabDbContext _context;

        public BookController(KitabDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allbooks = _context.Books.Include(n => n.Publisher).OrderBy(n => n.Title).ToList();
            //LINQ - Table join garne ani chahiteko 
            //ViewBag
            return View(allbooks);
        }
    }
}
