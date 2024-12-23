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

        [HttpGet("all/{orderId}")]
        public async Task<IActionResult> GetAllCartItems(int orderId)
        {
            var items = await _cartService.GetAllCartItemsAsync(orderId);
            if (items == null || !items.Any())
            {
                return Ok(new List<CartItem>()); // Trả về danh sách rỗng thay vì null
            }
            return Ok(items);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] AddCartRequest request)
        {
            var result = await _cartService.AddToCartAsync(request);
            if (!result) return BadRequest("thêm sản phẩm thất bại");
            return Ok("sản phẩm đã được thêm.");
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromBody] UpdateCartItemQuantityRequest request)
        {
            var result = await _cartService.UpdateCartItemQuantityAsync(request);
            if (!result) return NotFound("Không tìm thấy giỏ hàng.");
            return Ok("Sản phẩm đã được cập nhật số lượng.");
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var result = await _cartService.RemoveFromCartAsync(id);
            if (!result) return NotFound("Không tìm thấy sản phẩm.");
            return Ok("Sản phẩm đã được xoá khỏi giỏ hàng.");
        }


    }
}
