namespace Bakery_API.DTO
{
    public class AddCartRequest
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public int Quantity { get; set; }
    }
}
