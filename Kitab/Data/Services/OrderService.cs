using Kitab.Models;

namespace Kitab.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly KitabDbContent _context;
        public OrderService(KitabDbContent context)
        {
            _context = context;
        }
        public Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            throw new NotImplementedException();
        }
    }
}
