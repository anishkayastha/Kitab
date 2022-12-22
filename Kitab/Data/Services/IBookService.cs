using Kitab.Data.Base;
using Kitab.Data.ViewModels;
using Kitab.Models;

namespace Kitab.Data.Services
{
    public interface IBookService: IEntityBaseRepository<Book>
    {
        Task<Book> GetBookByIdAsync(int id);
        Task<NewBookDropdownsVM> GetNewBookDropdownsValues();
        Task AddNewBookAsync(NewBookVM data);
        Task UpdateBookAsync(NewBookVM data);
    }
}
