using BakeryShop.Areas.Admin.ViewModels;
using BakeryShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BakeryShop.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DashboardController : Controller
    {
        private readonly ApiService _apiService;

        public DashboardController(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            string url = "https://localhost:7056/api/Admin/GetAllProducts";
            var products = await _apiService.GetAllProduct(url);
            var productVM = products.Select(x => new ProductVM
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                Img = x.Img
            }).ToList();
            return View(productVM);
        }

        [HttpGet]
        public async Task<IActionResult> ProductAdd()
        {
            string categoryURL = "https://localhost:7056/api/Admin/GetAllCategories";
            string groupURL = "https://localhost:7056/api/Admin/GetAllGroups";

            var categories = await _apiService.GetCategoriesAsync(categoryURL);
            var groups = await _apiService.GetGroupsAsync(groupURL);

            ViewBag.ProductCategoryId = new SelectList(categories, "ProductId", "Name");
            ViewBag.GroupProductId = new SelectList(groups, "GroupId", "Name");
            return View(new AddProductVM());
        }

        [HttpPost]
        public async Task<IActionResult> ProductAdd(AddProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                string url = "https://localhost:7056/api/Admin/AddProduct";
                var response = await _apiService.AddProductAsync(url, productVM);
                if (response.Success)
                {
                    return RedirectToAction("ProductList");
                }
                ModelState.AddModelError(string.Empty, response.Message);
            }

            string categoryURL = "https://localhost:7056/api/Admin/GetCategories";
            string groupURL = "https://localhost:7056/api/Admin/GetGroups";

            var categories = await _apiService.GetCategoriesAsync(categoryURL);
            var groups = await _apiService.GetGroupsAsync(groupURL);

            ViewBag.ProductCategoryId = new SelectList(categories, "ProductId", "Name");
            ViewBag.GroupProductId = new SelectList(groups, "GroupId", "Name");

            return View(productVM);
        }
    }
}
