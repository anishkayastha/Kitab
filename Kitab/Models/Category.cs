namespace Kitab.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        //Relationship
        public List<Category_Book> Categories_Books { get; set; }
    }
}
