namespace BakeryShop.Areas.Admin.ViewModels
{
    public class ProductVM
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public string FormatPrice => Price.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture) + "đ";
    }
}
