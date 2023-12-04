using RiceTrader.Models;

namespace RiceTrader.Helpers
{
    public class OrderService
    {
        private readonly AppDbContext _context;

        public OrderService(AppDbContext context) // Changed to AppDbContext
        {
            _context = context;
        }

        public async Task AddOrderAsync(Order order)
        {
            _context.Orders.Add(order); 
            await _context.SaveChangesAsync();
        }

        public async Task AddOrUpdateOrderAsync(Order order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(o => o.ProductId == order.ProductId);

            if (existingOrder != null)
            {
                // Update existing order
                existingOrder.ProductName = order.ProductName;
                existingOrder.ProductSize = order.ProductSize;
                existingOrder.Price = order.Price;
                existingOrder.Currency = order.Currency;
                existingOrder.Quantity = order.Quantity;
            }
            else
            {
                // Add new order
                _context.Orders.Add(order);
            }

            await _context.SaveChangesAsync();
        }

    }
}
