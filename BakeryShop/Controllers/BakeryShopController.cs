using BakeryShop.Data;
using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BakeryShop.Controllers
{


    public class BakeryShopController : Controller
    {
        private readonly ILogger<BakeryShopController> _logger;
        public BakeryShopController(ILogger<BakeryShopController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login() { return View(); }
        public IActionResult Register() { return View(); }
        public IActionResult Basket() { return View(); }
        public IActionResult Track() { return View(); }

    }
}
