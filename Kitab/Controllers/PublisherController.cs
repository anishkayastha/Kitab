using Kitab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Controllers
{
    public class PublisherController : Controller
    {
        private readonly KitabDbContext _context;

        public PublisherController(KitabDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allPublishers = await _context.Publishers.ToListAsync();
            return View(allPublishers);
        }
    }
}
