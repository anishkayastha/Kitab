using Kitab.Data.Base;
using Kitab.Models;

namespace Kitab.Data.Services
{
    public interface IBookService: IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
    }
}
