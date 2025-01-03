namespace BakeryShop.Services
{

    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }

        public string FormatPrice => Price.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture) + "đ";

    }



    public class ResponseServices<T>
    {
        public T Data { get; set; }  // Dữ liệu tổng quát
        public bool Success { get; set; } // Trạng thái có thành công hay không
        public string Message { get; set; } // Thông báo
    }

    public class Group
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }

}
