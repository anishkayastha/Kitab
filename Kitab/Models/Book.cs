using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kitab.Data.Base;

namespace Kitab.Models
{
    public class Book : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Price")]
        public double Price { get; set; }

        [Display(Name = "Cover")]
        public string? ImageURL { get; set; }

        [Display(Name = "Publication date")]
        public DateTime PublishedDate { get; set; }


        //Category
        //public int CategoryId { get; set; }
        //[ForeignKey("CategoryId")]
        //public Category? Category { get; set; }

        //Relationships
        public List<Category_Book>? Categories_Books { get; set; }
        public List<Author_Book>? Authors_Books { get; set; }

        //Author
        /*public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }*/

        //Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher? Publisher { get; set; }

    }
}
