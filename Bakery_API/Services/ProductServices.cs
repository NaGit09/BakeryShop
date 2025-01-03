using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bakery_API.Services
{
    public class ProductServices : IProduct
    {
        private readonly BakeryShopContext _bakerySqlContext;

        public ProductServices(BakeryShopContext bakerySqlContext)
        {
            _bakerySqlContext = bakerySqlContext;
        }
        public List<dynamic> SearchProduct(String input="")
        {
                var products = _bakerySqlContext.Products.Where(x => x.Name.Contains(input)).Select(x => new { x.Name, x.description, x.ProductId, x.Price })
                .ToList();
            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> FilterById(int id)
        {
            var products = _bakerySqlContext.Products
                .Select(x => new { x.Price, x.Name, x.description, x.Img, x.ProductId }).Where(x => x.ProductId == id)
                .ToList();

            return products.Cast<dynamic>().ToList();
        }
        public List<dynamic> GetProductsStore()
        {
            var categoriesWithProducts = _bakerySqlContext.ProductCategories
        .Select(pc => new
        {
            CategoryName = pc.Name,
            Description = pc.Description,
            Products = pc.Products.Select(p => new
            {
                Name = p.Name,
                Price = p.Price,
                Img = p.Img,
                ProductId = p.ProductId
            })
        })
        .Cast<dynamic>().ToList();

            return categoriesWithProducts;

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
            var products = _bakerySqlContext.Products.Where(pr => pr.GroupProductId == GroupProductId).Select(x => new { x.ProductId, x.description, x.Price, x.Name, x.Img }).ToList();
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
                var products = _bakerySqlContext.Products.OrderBy(x => x.Price).Select(x => new { x.Name, x.description, x.Price, x.ProductId }).ToList();
                return products.Cast<dynamic>().ToList();
            }
            else if (type == "desc")
            {
                var products = _bakerySqlContext.Products.OrderByDescending(x => x.Price).Select(x => new { x.Name, x.description, x.Price, x.ProductId }).ToList();
                return products.Cast<dynamic>().ToList();
            }
            return null;
        }
    }
}
