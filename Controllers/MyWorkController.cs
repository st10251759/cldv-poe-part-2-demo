using Khumalo_Craft_P2.Data;
using Khumalo_Craft_P2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Khumalo_Craft_P2.Controllers
{
    [Authorize(Roles = "Client,Admin")]
    public class MyWorkController : Controller
    {
        private readonly KhumaloCraftDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public MyWorkController(KhumaloCraftDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            var product = _context.Product.FirstOrDefault(p => p.ProductId == productId && p.Availability == true);
            // Check if there's an existing open order for the user
            var openOrder = await _context.Orders
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "Shopping");

            if (openOrder == null)
            {
                // If no open order exists, create a new one
                openOrder = new Order
                {
                    UserId = userId,
                    OrderDate = DateTime.Now,
                    Status = "Shopping"
                };
                _context.Orders.Add(openOrder);
                await _context.SaveChangesAsync();
            }

            var orderRequest = new OrderRequest
            {
                OrderId = openOrder.OrderId,
                ProductId = productId,
                OrderStatus = "Pending"
            };
            _context.OrderRequests.Add(orderRequest);

            // Update product availability to "Out of Stock"
            product.Availability = false;

            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        public async Task<IActionResult> Cart()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            var openOrder = await _context.Orders
                .Include(o => o.OrderRequests)
                .ThenInclude(or => or.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "Shopping");

            return View(openOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = await _userManager.GetUserIdAsync(user);

            var openOrder = await _context.Orders
                .Include(o => o.OrderRequests)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "Shopping");

            if (openOrder == null || !openOrder.OrderRequests.Any())
            {
                return Json(new { success = false, message = "No items in cart" });
            }

            openOrder.Status = "Pending";
            await _context.SaveChangesAsync();

            return Json(new { success = true });

        }



        [HttpPost]
        public IActionResult CheckProductAvailability(int productId)
        {
            // Check if product is available
            var product = _context.Product.FirstOrDefault(p => p.ProductId == productId && p.Availability == true);

            if (product != null)
            {
                // Product is available
                return Json(new { success = true });
            }
            else
            {
                // Product is not available
                // If product is not available, return error
                return Json(new { success = false, message = "Product is not available" });

            }
        }

    }
}
