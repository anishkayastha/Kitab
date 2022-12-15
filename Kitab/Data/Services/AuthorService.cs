using Kitab.Data.Base;
using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Services
{
    public class AuthorService : EntityBaseRepository<Author>, IAuthorService
    {
        public AuthorService(KitabDbContext context) : base(context)
        {
        }
    }
}
