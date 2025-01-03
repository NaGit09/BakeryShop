using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Bakery_API.Services
{
    public class ProductServices : IProduct
    {
        private readonly BakeryShopContext _bakerySqlContext;

        public ProductServices(BakeryShopContext bakerySqlContext)
        {
            _bakerySqlContext = bakerySqlContext;
        }

        public List<Product> GetByProductCategoryName(string productCategoryName)
        {
            if (string.IsNullOrWhiteSpace(productCategoryName))
                return new List<Product>(); // Trả về danh sách rỗng nếu input không hợp lệ

            // Chuyển query về chữ thường để đảm bảo so sánh không phân biệt chữ hoa/thường
            var lowerCaseQuery = productCategoryName.ToLower();

            // Thực hiện truy vấn EF Core
            var products = _bakerySqlContext.Products
                .Where(item => EF.Functions.Like(item.Name.ToLower(), $"{lowerCaseQuery}%")) // Sử dụng LIKE
                .Take(5) // Giới hạn 5 kết quả
                .ToList();

            return products;
        }

        public List<dynamic> SearchProduct(String input = "")
        {
            var products = _bakerySqlContext.Products.Where(x => x.Name.Contains(input)).Select(x => new { x.Name, x.Description, x.ProductId, x.Price })
            .ToList();
            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> FilterById(int id)
        {
            var products = _bakerySqlContext.Products
                .Select(x => new { x.Price, x.Name, x.Description, x.Img, x.ProductId }).Where(x => x.ProductId == id)
                .ToList();

            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> GetProductsStore()
        {
            var products = _bakerySqlContext.Products.Include(x => x.ProductCategory).Select(x => new { x.Price, x.Name, x.Description, x.GroupProduct, x.Img });



            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> GetProducts()
        {
            var products = new List<dynamic>();

            for (var i = 1; i < 10; i++)
            {
                products.AddRange(GetByProductGroupProductId(i).Take(8));
            }

            return products;
        }
        public List<dynamic> GetByProductCategoryId(int CategoryId)
        {
            var products = _bakerySqlContext.Products.Where(pr => pr.ProductCategoryId == CategoryId).ToList();
            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> GetByProductGroupProductId(int GroupProductId)
        {
            var products = _bakerySqlContext.Products.Where(pr => pr.GroupProductId == GroupProductId).Select(x => new { x.ProductId, x.Description, x.Price, x.Name, x.Img }).ToList();
            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> Order(String type)
        {
            if (type == null)
            {
                return GetProducts();
            }
            else if (type == "asc")
            {
                var products = _bakerySqlContext.Products.OrderBy(x => x.Price).Select(x => new { x.Name, x.Description, x.Price, x.ProductId }).ToList();
                return products.Cast<dynamic>().ToList();
            }
            else if (type == "desc")
            {
                var products = _bakerySqlContext.Products.OrderByDescending(x => x.Price).Select(x => new { x.Name, x.Description, x.Price, x.ProductId }).ToList();
                return products.Cast<dynamic>().ToList();
            }
            return null;
        }
    }



}
