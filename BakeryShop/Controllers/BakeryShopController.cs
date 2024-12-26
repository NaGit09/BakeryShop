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
            _apiService=apiService;
        }

     public async Task<IActionResult> Index()
{
  
            // Giả sử GetAsync là hàm gọi API và trả về dữ liệu
            string url = "https://localhost:7056/api/Product/GetAll";
            var response = await _apiService.GetAsync<ResponseServices<List<Product>>>(url);
           
            // Truyền danh sách sản phẩm đến View
            return View(response);
        }
        public String ProductDetail(int id)
        {
            return id+"";
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
