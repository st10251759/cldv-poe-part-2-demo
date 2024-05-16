using Microsoft.AspNetCore.Mvc;

namespace Khumalo_Craft_P2.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
