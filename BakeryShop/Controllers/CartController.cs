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

        public async Task<IActionResult> Index(int orderId)
        {
            var items = await _cartService.GetAllCartItemsAsync(orderId);
            return View(items);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(UpdateCartQuantity request)
        {
            if (!ModelState.IsValid) return View("Error");

            var success = await _cartService.AddToCartAsync(request);
            if (!success) return View("Error");

            return RedirectToAction("Index", new { orderId = request.CartItemId });
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCart(UpdateCartQuantity request)
        {
            if (!ModelState.IsValid) return View("Error");

            var success = await _cartService.UpdateCartItemQuantityAsync(request);
            if (!success) return View("Error");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var success = await _cartService.RemoveFromCartAsync(id);
            return success ? RedirectToAction("Index") : View("Error");
        }


    }
}
