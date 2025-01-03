using Bakery_API.DTO.AdminDTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery_API.Services
{
    public class AdminService : IAdmin
    {
        private readonly BakeryShopContext _bakerySqlContext;

        public AdminService(BakeryShopContext bakeryShopContext)
        {
            _bakerySqlContext = bakeryShopContext ?? throw new ArgumentNullException(nameof(bakeryShopContext));
        }



        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _bakerySqlContext.Products
                .Include(p => p.ProductCategory)
                .Include(p => p.GroupProduct)
                .Select(p => new ProductDTO
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Price = p.Price,
                    Discount = p.Discount,
                    ProductCategoryName = p.ProductCategory.Name,
                    GroupProductName = p.GroupProduct.Name,
                    Description = p.Description,
                    Img = p.Img
                }).ToListAsync();
            return products;
        }


        public async Task<Product> AddProductAsync(AddProduct productDTO)
        {
            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price,
                Discount = productDTO.Discount,
                Description = productDTO.Description,
                Img = productDTO.Img,
                ProductCategoryId = productDTO.ProductCategoryId,
                GroupProductId = productDTO.ProductGroupId
            };
            _bakerySqlContext.Products.Add(product);
            await _bakerySqlContext.SaveChangesAsync();
            return product;
        }



        public async Task<List<CategoryWithProductsDTO>> GetAllCategoriesAsync()
        {
            var categories = await _bakerySqlContext.ProductCategories.
                Include(c => c.Products)
                .Select(c => new CategoryWithProductsDTO
                {
                    CategoryId = c.ProductCategoryId,
                    Name = c.Name,
                    Products = c.Products.Select(p => new ProductDTO
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Price = (decimal)p.Price,
                        Discount = (decimal)p.Discount,
                        Description = p.Description,
                    }).ToList()
                }).ToListAsync();
            return categories;
        }

        public async Task<List<GroupWithProductsDTO>> GetAllGroupsAsync()
        {
            var groups = await _bakerySqlContext.GroupProducts
                .Include(g => g.Products)
                .Select(g => new GroupWithProductsDTO
                {
                    GroupId = g.GroupProductId,
                    Name = g.Name,
                    Products = g.Products.Select(p => new ProductDTO
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Price = (decimal)p.Price,
                        Discount = (decimal)p.Discount,
                        Description = p.Description
                    }).ToList()
                }).ToListAsync();
            return groups;
        }


    }
}
