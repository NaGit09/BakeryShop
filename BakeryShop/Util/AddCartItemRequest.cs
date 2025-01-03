namespace BakeryShop.Util
{
    public class AddCartItemRequest
    {
        public int CartId { get; set; } // //Dùng để xác định giỏ hàng tương tự như sessionID
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
