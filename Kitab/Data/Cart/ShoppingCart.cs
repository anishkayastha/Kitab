using Kitab.Models;
using Microsoft.EntityFrameworkCore;

namespace Kitab.Data.Cart
{
    public class ShoppingCart
    {
        public KitabDbContext _context { get; set; }
        public string? ShoppingCartId { get; set; }
        public List<ShoppingCartItem>? ShoppingCartItems { get; set; }

        public ShoppingCart(KitabDbContext context)
        {
            _context = context;
        }

        public void AddItemToCart(Book book)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book.Id == book.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Book = book,
                    Amount = 1,
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Book).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => 
            n.Book!.Price * n.Amount).Sum();
    }
}
