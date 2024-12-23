namespace Bakery_API.DTO
{
    public class UpdateCartItemQuantityRequest
    {
        public int ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }
    }
}
