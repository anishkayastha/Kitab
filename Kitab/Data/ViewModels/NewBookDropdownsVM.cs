using Kitab.Data.Services;
using Kitab.Models;

namespace Kitab.Data.ViewModels
{
    public class NewBookDropdownsVM
    {
        public NewBookDropdownsVM()
        {
            Publishers = new List<Publisher>();
            Categories = new List<Category>();
            Authors = new List<Author>();
        }

        public List<Publisher> Publishers { get; set; }
        public List<Category> Categories { get; set; }
        public List<Author> Authors { get; set; }
    }
}
