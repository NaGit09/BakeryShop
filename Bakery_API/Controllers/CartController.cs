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

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart( [FromBody]AddCartRequest request)
        {
            if (request == null || request.Quantity <= 0)
            {
                return BadRequest("yêu cầu không hợp lệ");
            }

            try
            {
                await _cartService.AddCartAsync(request);
                return Ok("Thêm vào giỏ hàng thành công");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("userId")]
        public async Task<IActionResult> getCartItem(int userID)
        {
            try
            {
                var cartItems = await _cartService.GetCartItemsAsync(userID);
                if (cartItems == null)
                {
                    return NotFound("Không có sản phẩm nào trong giỏ hàng");
                }
                return Ok(cartItems);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCartItemQuantity([FromBody] UpdateCartItemQuantityRequest request)
        {
            if (request == null || request.Quantity <= 0)
            {
                return BadRequest("Yêu cầu không hợp lệ. Số lượng phải lớn hơn 0.");
            }

            try
            {
                var isUpdated = await _cartService.UpdateCartItemQuantityAsync(request.CartItemId, request.Quantity);

                if (!isUpdated)
                {
                    return NotFound("Không tìm thấy sản phẩm trong giỏ hàng hoặc số lượng không hợp lệ.");
                }

                return Ok("Cập nhật số lượng sản phẩm thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }


        [HttpDelete("remove/{cartItemId}")]
        public async Task<IActionResult> RemoveFromCart(int cartItemId)
        {
            try
            {
                var isRemoved = await _cartService.RemoveFromCartAsync(cartItemId);

                if (!isRemoved)
                {
                    return NotFound("Không tìm thấy sản phẩm trong giỏ hàng để xóa.");
                }

                return Ok("Xóa sản phẩm khỏi giỏ hàng thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Lỗi: {ex.Message}");
            }
        }


    }
}
