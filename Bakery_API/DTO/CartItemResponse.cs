namespace Bakery_API.DTO
{
    public class CartItemResponse
    {
        public int CartItemId { get; set; }
        public required string ProductName { get; set; } // Bắt buộc gán giá trị khi khởi tạo
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
    }
}
