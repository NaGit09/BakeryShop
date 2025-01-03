using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;

namespace BakeryShop.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpPost]
        public IActionResult ProcessCheckout([FromBody] CheckoutRequest request)
        {
            if (string.IsNullOrEmpty(request.ShippingAddress) || string.IsNullOrEmpty(request.ContactNumber))
            {
                return BadRequest("Thông tin giao hàng không đầy đủ.");
            }

            return Ok(new { Message = "Thanh toán thành công!" });
        }
    }
}
