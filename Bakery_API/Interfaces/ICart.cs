using Bakery_API.DTO;
using Bakery_API.Models;

namespace Bakery_API.Interfaces
{
    public interface ICart
    {
        // tác vụ 

        /// Lấy danh sách sản phẩm trong giỏ hàng theo CartId (ID của giỏ hàng)
        Task<List<CartItemResponse>> GetCartItemsAsync(int cartId);

        /// Thêm sản phẩm vào giỏ hàng
        Task<bool> AddCartItemAsync(AddCartItemRequest request);

        /// Cập nhật số lượng sản phẩm trong giỏ hàng
        Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemQuantityRequest request);

        /// Xóa sản phẩm khỏi giỏ hàng theo cartItemId (ID của sản phẩm trong giỏ hàng)
        /// và cartId (ID của giỏ hàng)
        Task<bool> RemoveCartItemAsync(int cartItemId, int cartId);

    }
}
