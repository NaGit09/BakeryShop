using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_API.Services
{
    public class ProductServices : IProduct
    {
        private readonly BakeryShopContext _bakerySqlContext;

        public ProductServices(BakeryShopContext bakerySqlContext)
        {
            _bakerySqlContext = bakerySqlContext;
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
