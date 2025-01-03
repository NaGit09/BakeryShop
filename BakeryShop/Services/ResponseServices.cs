﻿namespace BakeryShop.Services
{
    public class Category
    {
        public String? CategoryName { get; set; }
        public String? Description { get; set; }
        public List<Product>? Products { get; set; }

    }
    public class Product
    {
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Img { get; set; }
    }
    public class ResponseServices<T>
    {
        public T? Data { get; set; }  // Dữ liệu tổng quát
        public bool Success { get; set; } // Trạng thái có thành công hay không
        public string Message { get; set; } // Thông báo
    }



}
