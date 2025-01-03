namespace BakeryShop.Util
{
    public class CheckoutRequest
    {

        // thanh toán
        public int CartId { get; set; }
        public required string PaymentMethod { get; set; }
        public required string ShippingAddress { get; set; }
        public required string ContactNumber { get; set; }
    }
}
