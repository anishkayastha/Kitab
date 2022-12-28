using Kitab.Models;
using Microsoft.EntityFrameworkCore;
using System;

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

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext!.Session;
            var context = services.GetService<KitabDbContext>();

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context!) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(Book book)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book!.Id == book.Id && 
                n.ShoppingCartId == ShoppingCartId);

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

        public void RemoveItemFromCart(Book book)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Book!.Id == book.Id &&
                n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                .Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Book).ToList());
        }

        public double GetShoppingCartTotal() => _context.ShoppingCartItems
            .Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Book!.Price * n.Amount).Sum();
    }
}
