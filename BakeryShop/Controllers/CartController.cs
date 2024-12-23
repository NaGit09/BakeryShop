using BakeryShop.Services;
using Bakery_API.DTO;
using Microsoft.AspNetCore.Mvc;
using BakeryShop.Util;

namespace BakeryShop.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index(int userId)
        {
            try
            {
                // Lấy danh sách giỏ hàng từ API
                var cartItems = await _cartService.GetCartItemsAsync(userId);

                // Nếu giỏ hàng trống
                if (cartItems == null || !cartItems.Any())
                {
                    ViewBag.Message = "Giỏ hàng của bạn đang trống.";
                    return View(new List<ShoppingCartItem>());
                }

                return View(cartItems);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu API gặp vấn đề
                ViewBag.ErrorMessage = $"Lỗi: {ex.Message}";
                return View(new List<ShoppingCartItem>());
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(AddCartRequest request)
        {
            if (request == null || request.Quantity <= 0)
            {
                return BadRequest("Yêu cầu không hợp lệ.");
            }

            try
            {
                await _cartService.AddToCartAsync(request);
                return RedirectToAction("Index", new { userId = request.UserId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", new { userId = request.UserId });
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCartItem(UpdateCartItemQuantityRequest request)
        {
            if (request == null || request.Quantity <= 0)
            {
                return BadRequest("Số lượng phải lớn hơn 0.");
            }

            try
            {
                await _cartService.UpdateCartItemAsync(request);
                return RedirectToAction("Index", new { userId = 1 }); // Thay userId bằng giá trị thực tế
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", new { userId = 1 });
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            try
            {
                await _cartService.RemoveCartItemAsync(cartItemId);
                return RedirectToAction("Index", new { userId = 1 }); // Thay userId bằng giá trị thực tế
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"Lỗi: {ex.Message}";
                return RedirectToAction("Index", new { userId = 1 });
            }
        }



    }
}
