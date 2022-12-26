﻿using System.ComponentModel.DataAnnotations;

namespace Kitab.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Book? Book { get; set; }
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
