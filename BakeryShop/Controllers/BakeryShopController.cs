using BakeryShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BakeryShop.Controllers
{
    

    public class BakeryShopController : Controller { 
        private readonly ILogger<BakeryShopController> _logger;
        public BakeryShopController (ILogger<BakeryShopController> logger)
        {
            _logger = logger;
        }
    
        public IActionResult Index()
        {
            ViewData["userName"] = "nhutanh";
            Cake cake = new Cake();
            cake.Price = 100;   
            cake.Weight = 100;
            cake.Description = string.Empty;
            cake.Name = string.Empty;
            return View(cake);
        }
    }
}
