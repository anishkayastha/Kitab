using Kitab.Data.Base;
using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        private readonly KitabDbContext _context;
        public AuthorService(KitabDbContext context) : base(context)
        {
        }
    }
}
