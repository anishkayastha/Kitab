﻿namespace Kitab.Models
{
    public class Category_Book
    {
        public int? BookId { get; set; }
        public Book Book { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
