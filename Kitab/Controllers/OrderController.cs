using Kitab.Data.Cart;
using Kitab.Data.Services;
using Kitab.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kitab.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ShoppingCart _shoppingCart;
        public OrderController(IBookService bookService, ShoppingCart shoppingCart)
        {
            _bookService = bookService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal();
            };
            return View(response);
        }
    }
}
