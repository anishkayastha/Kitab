using Kitab.Data.Base;
using Kitab.Models;

namespace Kitab.Data.Services
{
    public class BookService : EntityBaseRepository<Book>, IBookService
    {
        public BookService(KitabDbContext context) : base(context)
        {

        }
    }
}
