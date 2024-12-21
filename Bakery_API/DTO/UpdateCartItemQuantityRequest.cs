namespace Bakery_API.DTO
{
    public class UpdateCartItemQuantityRequest
    {
        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
