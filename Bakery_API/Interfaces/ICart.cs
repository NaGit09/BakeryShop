using Bakery_API.DTO;
using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface ICart
    {
        // tác vụ thêm giỏ hàng , quy ước đi kèm hậu tố Async/Await khi kế thừa
        // Thêm giỏ hàng
        Task AddCartAsync(AddCartRequest request);

         //Lấy danh sách mặt hàng trong giỏ hàng
        Task<List<ShoppingCartItem>> GetCartItemsAsync(int userId);

        // Xóa mặt hàng khỏi giỏ hàng
        Task<bool> RemoveFromCartAsync(int cartItemId);

        //// Cập nhật số lượng mặt hàng trong giỏ hàng
        Task<bool> UpdateCartItemQuantityAsync(int cartItemId, int quantity);
    }
}
