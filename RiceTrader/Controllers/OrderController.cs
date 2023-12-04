using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiceTrader.Models;
using System.Linq;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using RiceTrader.Helpers;

namespace RiceTrader.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
        public OrderController(AppDbContext context)
        {
            _context = context;
            _httpClient = HttpClientHelper.GetHttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders.ToListAsync();
            return View(orders);
        }

        public async Task<IActionResult> EditQuantity(int orderId)
        {
            ViewData["EditingOrderId"] = orderId;
            var orders = await _context.Orders.ToListAsync();
            return View("Index", orders); //redirect to Index
        }


        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(int orderId, int newQuantity)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return NotFound();
            }

            order.Quantity = newQuantity;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> SendOrder()
        {
            var orders = await _context.Orders.ToListAsync();

            var orderRequest = new OrderApiRequest
            {
                CustomerId = 4, // Assuming a static customer ID
                OrderDate = DateTime.UtcNow,
                Items = orders.Select(o => new OrderItemDto
                {
                    ProductId = o.ProductId,
                    Quantity = o.Quantity
                }).ToList()
            };

            var jsonRequest = JsonSerializer.Serialize(orderRequest);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/Order", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<OrderApiResponse>(responseContent,new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
               // var apiResponse = JsonSerializer.Deserialize<OrderApiResponse>(responseContent);

                // Create FinalOrder records first
                var finalOrders = orders.Select(o => new FinalOrder
                {
                    ProductId = o.ProductId,
                    Quantity = o.Quantity,
                    Price = o.Price,
                    VendorId = o.VendorId,
                    VendorName = o.VendorName,
                    ProductName = o.ProductName,
                    ProductSize = o.ProductSize,
                    Currency = o.Currency
                    // PoId is not set yet as PurchaseOrder hasn't been created
                }).ToList();
                    
                var po = new PurchaseOrder
                {
                    OrderDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                    TotalPrice = apiResponse.TotalPrice,
                    Currency = "CAD",
                    // Do not add FinalOrders here yet, as they don't have IDs
                };

                _context.PurchaseOrders.Add(po);
                await _context.SaveChangesAsync(); // Save the PurchaseOrder to generate PoId


                // Now that we have PoId, update it in each FinalOrder
                finalOrders.ForEach(fo => fo.PoId = po.PoId);
                _context.FinalOrders.AddRange(finalOrders);

                // Remove the processed orders
                _context.Orders.RemoveRange(orders);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "PurchaseOrder");
            }
            else
            {
                // Handle failure scenarios
                var errorContent = await response.Content.ReadAsStringAsync();
                ViewBag.Error = errorContent;
                return View("Error");
            }
        }



    }
}
