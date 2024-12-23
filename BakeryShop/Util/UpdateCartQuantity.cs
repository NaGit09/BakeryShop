using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class UpdateCartQuantity
    {
        [Required]
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
