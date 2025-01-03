using BakeryShop.Filter;
using BakeryShop.Services;
using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text.Json;

namespace BakeryShop.Controllers
{


    public class BakeryShopController : Controller
    {
        private readonly ApiService _apiService;
        private readonly CartService _cartService;


        public BakeryShopController(ApiService apiService, CartService cartService)
        {
            _apiService = apiService;
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {

            // Giả sử GetAsync là hàm gọi API và trả về dữ liệu
            string url = "https://localhost:7056/api/Product/GetAll";
            var response = await _apiService.GetAsync2<ResponseServices<List<Services.Product>>>(url);

            // Truyền danh sách sản phẩm đến View
            return View(response);
        }
        public async Task<IActionResult> store()
        {

            // Giả sử GetAsync là hàm gọi API và trả về dữ liệu
            string url = "https://localhost:7056/api/Product/GetAll";
            var response = await _apiService.GetAsync2<ResponseServices<List<Services.Product>>>(url);
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> store(String type)
        {
            String url = "https://localhost:7056/api/Product/SearchProduct?input=" + type;
            var response = await _apiService.GetAsync2<ResponseServices<List<Services.Product>>>(url);
            return View(response);
        }
        public String ProductDetail(int id)
        {
            return id + "";
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
        public IActionResult ForgotPassword()
        {

            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();

        }
   

        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult User()
        {
            return View();
        }
        [ServiceFilter(typeof(LoginFilter))]
        public IActionResult Track()
        {
            return View();
        }
        [ServiceFilter(typeof(LoginFilter))]
        public async Task<IActionResult> Basket()
        {

            var token = Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                var userId = int.Parse(jsonToken?.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value);
                var cartItems =  await _cartService.GetCartItemsAsync(userId);

                return View("Basket", cartItems);

            }
            return RedirectToAction("ConfirmOTP", "BakeryShop"); // Chuyển hướng đến trang chính
        }

    }

}