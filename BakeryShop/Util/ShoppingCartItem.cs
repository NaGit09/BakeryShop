using BakeryShop.Util;

namespace BakeryShop.Util
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice => Quantity * ProductPrice; // Tổng tiền cho sản phẩm


    }
}
