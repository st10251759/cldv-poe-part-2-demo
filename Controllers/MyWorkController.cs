using Microsoft.AspNetCore.Mvc;

namespace Khumalo_Craft_P2.Controllers
{
    public class MyWorkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
