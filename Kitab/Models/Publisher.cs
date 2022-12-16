using Kitab.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitab.Models
{
    public class Publisher : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo")]
        [Required(ErrorMessage = "Profile Picture is required")]
        public string? Logo { get; set; }

        [Display(Name = "Publisher Name")]
        [Required(ErrorMessage = "Publisher Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Publisher Name must be between 3 and 50 chars")]
        public string? Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be less than 100 chars")]
        public string? Description { get; set; }

        //Relationships
        public List<Book>? Books { get; set; }
    }
}
