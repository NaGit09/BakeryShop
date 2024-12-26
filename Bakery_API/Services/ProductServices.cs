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
        public List<dynamic> FilterById(int id)
        {
            var products = _bakerySqlContext.Products
                .Select(x => new { x.Price, x.Name, x.description, x.Img , x.ProductId }).Where(x => x.ProductId == id)
                .ToList();

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
            var products = _bakerySqlContext.Products.Where(pr => pr.GroupProductId == GroupProductId).Select(x=> new {x.ProductId , x.description , x.Price , x.Name , x.Img}).ToList();
            return products.Cast<dynamic>().ToList();
        }
    }
}
