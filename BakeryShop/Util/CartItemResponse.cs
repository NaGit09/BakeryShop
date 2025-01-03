namespace BakeryShop.Util
{
    public class CartItemResponse
    {
        public int CartItemId { get; set; }
        public required string ProductName { get; set; } 
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
