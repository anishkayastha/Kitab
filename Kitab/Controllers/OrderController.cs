using Kitab.Data.Cart;
using Kitab.Data.Services;
using Kitab.Data.ViewModels;
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
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };
            return View(response);
        }

        //This method is used to redirect to specified action instead of rendering the HTML. In this case,
        //the browser receives the redirect notification and make a new request for the specified action.
        public async Task<IActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var item = await _bookService.GetBookByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
