namespace Bakery_API.DTO.AdminDTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;

        public decimal? Price { get; set; }

        public decimal? Discount { get; set; }

        public string ProductCategoryName { get; set; }

        public string GroupProductName { get; set; }

        public string? Description { get; set; }

        public string? Img { get; set; }
    }

    public class GroupWithProductsDTO
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
    public class CategoryWithProductsDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
