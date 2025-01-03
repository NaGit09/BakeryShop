namespace BakeryShop.Areas.Admin.ViewModels
{
    public class AddProductVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public int ProductCategoryId { get; set; }
        public int GroupProductId { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
}
