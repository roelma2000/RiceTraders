using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using RiceTrader.Helpers;
using RiceTrader.Models;

namespace RiceTrader.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly OrderService _orderService;

        public ProductController(OrderService orderService)
        {
            _httpClient = HttpClientHelper.GetHttpClient();
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/Products"); 
            var responseString = await response.Content.ReadAsStringAsync();
            //Console.WriteLine($"Response String: {responseString}");
            if (response.IsSuccessStatusCode)
            {
                // Log the response string for debugging
                //Console.WriteLine(responseString); 

                var products = JsonSerializer.Deserialize<List<Product>>(responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(products);
            }
            else
            {
                // Log error for debugging
                Console.WriteLine($"API call failed: {response.StatusCode}");
            }

            return View(new List<Product>());
        }

        [HttpPost]
        public async Task<IActionResult> AddToOrderQueue(int productId, string productName, string productSize, decimal price, int quantity)
        {
            Order order = new Order
            {
                VendorId = 1,
                VendorName = "RiceLink Inc.",
                ProductId = productId,
                ProductName = productName,
                ProductSize = productSize,
                Price = price,
                Currency = "CAD",
                Quantity = quantity
            };

            await _orderService.AddOrUpdateOrderAsync(order);

            return RedirectToAction("Index", "Order"); // Redirect to view Order Queue
        }

    }
}
