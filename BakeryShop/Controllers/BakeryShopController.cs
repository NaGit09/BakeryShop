using BakeryShop.Models;
using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

namespace BakeryShop.Controllers
{


    public class BakeryShopController : Controller
    {
        private BakeryShopContext _sqlContext;
        public BakeryShopController(BakeryShopContext context)
        {
            _sqlContext = context;
        }

        public IActionResult Index()
        {
            List<Product> products = _sqlContext.Products.ToList();
            return View(products);
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
            RegisterValidation rv = new RegisterValidation();
            rv.genders = new List<SelectListItem>
            {
                    new SelectListItem {Value="Nam", Text="Nam"},
                    new SelectListItem {Value="Nữ", Text="Nữ"},
                    new SelectListItem {Value="Khác", Text="Khác"},
            };
            return View(rv); }
        [HttpPost]
        public IActionResult Register (RegisterValidation rv)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("/", "BakeryShop");
            }
            rv.genders = new List<SelectListItem>
            {
                    new SelectListItem {Value="Nam", Text="Nam"},
                    new SelectListItem {Value="Nữ", Text="Nữ"},
                    new SelectListItem {Value="Khác", Text="Khác"},
            };
            return View(rv);
        }
        public IActionResult Basket() { return View(); }
        public IActionResult Track() { return View(); }

    }
}
