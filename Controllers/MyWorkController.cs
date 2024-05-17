using Khumalo_Craft_P2.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Khumalo_Craft_P2.Controllers
{
    public class MyWorkController : Controller
    {
        private readonly KhumaloCraftDbContext _context;

        public MyWorkController(KhumaloCraftDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Product.ToListAsync());
        }
    }
}
