namespace Bakery_API.DTO.AdminDTO
{
    public class AddProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        public int ProductGroupId { get; set; }
        public string Img { get; set; }
    }
}
