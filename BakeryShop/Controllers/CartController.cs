using BakeryShop.Services;
using Bakery_API.DTO;
using Microsoft.AspNetCore.Mvc;
using BakeryShop.Util;
using UpdateCartItemQuantityRequest = BakeryShop.Util.UpdateCartItemQuantityRequest;
using CheckoutRequest = BakeryShop.Util.CheckoutRequest;

namespace BakeryShop.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            const int cartId = 1; // Sử dụng CartId cố định là 1
            ViewData["CartId"] = cartId;
            var cartItems = await _cartService.GetCartItemsAsync(cartId);
            return View("~/Views/BakeryShop/Basket.cshtml", cartItems);
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


        [HttpPost]
        public async Task<IActionResult> Checkout(CheckoutRequest request)
        {
            if (string.IsNullOrEmpty(request.ShippingAddress) || string.IsNullOrEmpty(request.ContactNumber))
            {
                TempData["Error"] = "Thông tin giao hàng không đầy đủ.";
                return RedirectToAction("Index");
            }

            var success = await _cartService.ProcessCheckoutAsync(request);

            if (success)
            {
                TempData["Message"] = "Thanh toán thành công!";
                return RedirectToAction("OrderSuccess");
            }

            TempData["Error"] = "Thanh toán thất bại. Vui lòng thử lại.";
            return RedirectToAction("Index");
        }

        public IActionResult OrderSuccess()
        {
            return View("~/Views/BakeryShop/OrderSuccess.cshtml");
        }



    }
}
