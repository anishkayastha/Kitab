using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kitab.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string? Name { get; set; }

        //Relationship
        public List<Category_Book> Categories_Books { get; set; }
    }
}
