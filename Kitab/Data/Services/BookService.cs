using Kitab.Data.Base;
using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Services
{
    public class BookService : EntityBaseRepository<Book>, IBookService
    {
        private readonly KitabDbContext _context;
        public BookService(KitabDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            var bookDetails = await _context.Books
                .Include(p => p.Publisher!)
                .Include(cb => cb.Categories_Books!)
                .Include(ab => ab.Authors_Books!)
                .ThenInclude(a => a.Author!)
                .FirstOrDefaultAsync(n => n.Id == id);

            return bookDetails!;
        }
    }
}
