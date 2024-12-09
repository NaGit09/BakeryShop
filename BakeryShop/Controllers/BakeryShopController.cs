using BakeryShop.Data;
using BakeryShop.Models;
using BakeryShop.Util;
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
        [HttpGet]
        public IActionResult Login() {

            ViewData["title"] = "Login";
            return View(); }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(LoginValidation lv) { 
            if (!ModelState.IsValid)
            {
                return View(lv);
            }
            return RedirectToAction("","BakeryShop");

            }
        [HttpGet]
        public IActionResult Register() {
            ViewData["Title"] = "Register";
            return View(); }
        [HttpPost]
        public IActionResult Register (RegisterValidation rv)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("/", "BakeryShop");
            }return View(rv);
        }
        public IActionResult Basket() { return View(); }
        public IActionResult Track() { return View(); }

    }
}
