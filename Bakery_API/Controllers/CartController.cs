using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICart _cartService;

        public CartController(ICart cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("{cartId}")]
        public async Task<IActionResult> GetCartItems(int cartId)
        {
            var cartItems = await _cartService.GetCartItemsAsync(cartId);
            return Ok(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> AddCartItem(AddCartItemRequest request)
        {
            var success = await _cartService.AddCartItemAsync(request);
            if (!success) return BadRequest("Thêm sản phẩm thất bại");
            return Ok("Thêm sản phẩm thành công");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCartItemQuantity(UpdateCartItemQuantityRequest request)
        {
            var success = await _cartService.UpdateCartItemQuantityAsync(request);
            if (!success) return BadRequest("Cập nhật số lượng sản phẩm thất bại");
            return Ok("Cập nhật số lượng sản phẩm thành công");
        }

        [HttpDelete("{cartItemId}/{cartId}")]
        public async Task<IActionResult> RemoveCartItem(int cartItemId, int cartId)
        {
            var success = await _cartService.RemoveCartItemAsync(cartItemId, cartId);
            if (!success) return BadRequest("Xoá sản phẩm khỏi giỏ hàng thất bại");
            return Ok("Xoá sản phẩm thành công");
        }

    }
}
