using Kitab.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Controllers
{
    public class CategoryController : Controller
    {
        private readonly KitabDbContext _context;

        public CategoryController(KitabDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var allCategories = await _context.Categories.ToListAsync();
            return View(allCategories);
        }
    }
}
