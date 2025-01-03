using BakeryShop.Services;
using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;

namespace BakeryShop.Controllers
{


    public class BakeryShopController : Controller
    {
        private readonly ApiService _apiService;

        public BakeryShopController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {

            // Giả sử GetAsync là hàm gọi API và trả về dữ liệu
            string url = "https://localhost:7056/api/Product/GetAll";
            var response = await _apiService.GetAsync<ResponseServices<List<Product>>>(url);

            // Truyền danh sách sản phẩm đến View
            return View(response);
        }
        public async Task<IActionResult> Store()
        {
            string url = "https://localhost:7056/api/Product/GetProductsStore";
            var response = await _apiService.GetAsyncStore<ResponseServices<List<Category>>>(url);
            return View(response);
        }


        [HttpPost]
        public async Task<IActionResult> store (String type)
        {
            String url = "https://localhost:7056/api/Product/SearchProduct?input="+type;
            var response = await _apiService.GetAsync<ResponseServices<List<Product>>>(url);
            return View(response);
        }
        public async Task<IActionResult> ProductDetail(int id)
        {
            String url = "https://localhost:7056/api/Product/FilterById?id=" + id;
            var response = await _apiService.GetAsync<ResponseServices<List<Product>>>(url);
            return View(response);
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
