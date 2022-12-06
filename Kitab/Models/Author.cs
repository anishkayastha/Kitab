using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kitab.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? ProfilePictureURL { get; set; }
        public string? Fullname { get; set; }
        public string? Bio { get; set; }

        //Relationships
        public List<Book> Book { get; set; }
    }
}
