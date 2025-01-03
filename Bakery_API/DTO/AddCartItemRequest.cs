namespace Bakery_API.DTO
{
    public class AddCartItemRequest
    {
        //Dùng để xác định giỏ hàng tương tự như sessionID
        public int CartId { get; set; } 
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
