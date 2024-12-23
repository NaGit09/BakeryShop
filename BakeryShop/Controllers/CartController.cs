using BakeryShop.Services;
using Bakery_API.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // Lấy danh sách sản phẩm trong giỏ hàng
        public async Task<IActionResult> Index(int userId)
        {
            var cartItems = await _cartService.GetCartItemsAsync(userId);
            return View(cartItems);
        }

        // Thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddCartRequest request)
        {
            await _cartService.AddToCartAsync(request);
            return RedirectToAction("Index", new { userId = request.UserId });
        }

        // Cập nhật số lượng sản phẩm
        [HttpPost]
        public async Task<IActionResult> UpdateCart(UpdateCartItemQuantityRequest request)
        {
            await _cartService.UpdateCartItemAsync(request);
            return RedirectToAction("Index", new { userId = request.CartItemId });
        }

        // Xóa sản phẩm khỏi giỏ hàng
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int cartItemId, int userId)
        {
            await _cartService.RemoveCartItemAsync(cartItemId);
            return RedirectToAction("Index", new { userId });
        }
    }
}
