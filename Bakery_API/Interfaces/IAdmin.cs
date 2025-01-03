using Bakery_API.DTO.AdminDTO;
using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface IAdmin
    {
        Task<List<ProductDTO>> GetAllProducts();
        Task<Product> AddProductAsync(AddProduct productDTO);

        Task<List<CategoryWithProductsDTO>> GetAllCategoriesAsync();
        Task<List<GroupWithProductsDTO>> GetAllGroupsAsync();
    }
}
