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

        public async Task<IActionResult> Index(int cartId)
        {
            var cartItems = await _cartService.GetCartItemsAsync(cartId);
            return View("~/Views/BakeryShop/Basket.cshtml",cartItems); 
        }


    }
}
