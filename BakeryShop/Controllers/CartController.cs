using BakeryShop.Services;
using Microsoft.AspNetCore.Mvc;
using BakeryShop.Util;
using UpdateCartItemQuantityRequest = BakeryShop.Util.UpdateCartItemQuantityRequest;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;

namespace BakeryShop.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }


        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(UpdateCartItemQuantityRequest request)
        {
            // Kiểm tra dữ liệu đầu vào
            if (request.Quantity <= 0)
            {
                ModelState.AddModelError("", "Số lượng phải lớn hơn 0.");
                return RedirectToAction("Index");
            }

            // Gọi service để cập nhật
            var result = await _cartService.UpdateCartItemQuantityAsync(request);
            if (!result)
            {
                TempData["Error"] = "Không thể cập nhật số lượng sản phẩm.";
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int cartItemId)
        {
            const int fixedCartId = 1; // Sử dụng CartId cố định là 1
            var result = await _cartService.RemoveCartItemAsync(cartItemId, fixedCartId);
            if (!result)
            {
                TempData["Error"] = "Không thể xóa sản phẩm.";
            }

            return RedirectToAction("Index");
        }



    }
}
