using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiceTrader.Models; 
using System.Linq;
using System.Threading.Tasks;

namespace RiceTrader.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly AppDbContext _context;

        public PurchaseOrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch all purchase orders including their related final orders
            var purchaseOrders = await _context.PurchaseOrders
                .Include(po => po.FinalOrders)
                .ToListAsync();

            return View(purchaseOrders);
        }
    }
}
