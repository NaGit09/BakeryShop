using Bakery_API.DTO;
using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface ICart
    {
        // tác vụ thêm giỏ hàng , quy ước đi kèm hậu tố Async/Await khi kế thừa
        // Thêm giỏ hàng
        Task<List<CartItem>> GetAllCartItemsAsync(int userId);
        Task<bool> AddToCartAsync(AddCartRequest request);
        Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemQuantityRequest request);
        Task<bool> RemoveFromCartAsync(int shoppingCartItemId);


    }
}
