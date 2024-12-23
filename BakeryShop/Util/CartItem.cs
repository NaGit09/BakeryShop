namespace BakeryShop.Util
{
    public class CartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //public string? ProductDescription { get; set; }
        //public string? ProductImageUrl { get; set; }
    }
}
