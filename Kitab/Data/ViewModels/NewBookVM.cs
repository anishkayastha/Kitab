using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kitab.Data.Base;
using Kitab.Models;

namespace Kitab.Data.ViewModels
{
    public class NewBookVM
    {
        public int Id { get; set; }

        [Display(Name = "Book Title")]
        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Display(Name = "Book Description")]
        [Required(ErrorMessage = "Description is required")]
        public string? Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Book Cover")]
        [Required(ErrorMessage = "Book Cover URL is required")]
        public string? ImageURL { get; set; }

        [Display(Name = "Publication Date")]
        [Required(ErrorMessage = "Publication Date is required")]
        public DateTime PublishedDate { get; set; }

        //Relationships
        [Display(Name = "Select Category(s)")]
        [Required(ErrorMessage = "Category(s) is required")]
        public List<int>? CategoryIds { get; set; }

        [Display(Name = "Select Author(s)")]
        [Required(ErrorMessage = "Author(s) is required")]
        public List<int>? AuthorIds { get; set; }

        [Display(Name = "Select a Publisher")]
        [Required(ErrorMessage = "Book Publisher is required")]
        public int PublisherId { get; set; }

    }
}
