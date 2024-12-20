using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface IProduct
    {
        List<Product> GetByProductGroupProductId(int GroupProductId);

        List<Product> GetByProductCategoryId (int productCategoryId);
        List<dynamic> GetProducts();


    }
}
