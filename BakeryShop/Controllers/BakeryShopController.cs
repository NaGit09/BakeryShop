using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;

namespace BakeryShop.Controllers
{


    public class BakeryShopController : Controller
    {

        public BakeryShopController()
        {
            ;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult login()
        {

            return View();
        }

        public IActionResult Register()
        {

            return View();
        }

        public IActionResult ConfirmOTP()
        {

            return View();
        }

    }

}
