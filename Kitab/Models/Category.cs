using Kitab.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kitab.Models
{
    public class Category : IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Category name is required")]
        public string? Name { get; set; }

        //Relationship
        public List<Category_Book>? Categories_Books { get; set; }
    }
}
