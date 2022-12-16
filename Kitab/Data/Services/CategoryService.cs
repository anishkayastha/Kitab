using Kitab.Data.Base;
using Kitab.Models;

namespace Kitab.Data.Services
{
    public class CategoryService : EntityBaseRepository<Category>, ICategoryService
    {
        public CategoryService(KitabDbContext context) : base(context)
        {

        }
    }
}
