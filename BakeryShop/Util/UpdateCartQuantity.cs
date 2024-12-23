using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class UpdateCartQuantity
    {
        [Required]
        public int CartItemId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0")]
        public int Quantity { get; set; }
    }
}
