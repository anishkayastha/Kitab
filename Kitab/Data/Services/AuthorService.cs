using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly KitabDbContext _context;
        public AuthorService(KitabDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync(); //find info on this
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Authors.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            var result = await _context.Authors.ToListAsync();  //Creates list from author context and stores in result
            return result;
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            var result = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Author> UpdateAsync(int id, Author newAuthor)
        {
            _context.Update(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }
    }
}
