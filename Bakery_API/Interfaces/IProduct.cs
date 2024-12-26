using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface IProduct
    {
        List<dynamic> GetByProductGroupProductId(int GroupProductId);
        List<dynamic> GetByProductCategoryId (int CategoryId);
        List<dynamic> GetProducts();
        List<dynamic> FilterById(int id);


    }
}
