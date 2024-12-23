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

        public ProductServices(BakeryShopContext bakerySqlContext) {
            _bakerySqlContext = bakerySqlContext;
        }
        public List<dynamic> GetProducts()
        {
            var products = _bakerySqlContext.Products
                .Select(x => new { x.Price, x.Name , x.description , x.Img})
                .ToList();

            return products.Cast<dynamic>().ToList();
        }
        public List<Product> GetByProductCategoryId(int productCategoryId)
        {
            var products = _bakerySqlContext.Products.Where(pr => pr.ProductId == productCategoryId).ToList();

            
                return products;

        }

        public List<Product> GetByProductGroupProductId(int GroupProductId)
        {
            throw new NotImplementedException();
        }
    }
}
