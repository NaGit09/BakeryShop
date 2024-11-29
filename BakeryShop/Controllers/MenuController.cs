using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }
    }
}
