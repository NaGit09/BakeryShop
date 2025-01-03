using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Bakery_API.Services
{
    public class CartServices : ICart
    {
        private readonly BakeryShopContext _context;

        public CartServices(BakeryShopContext context)
        {
            _context = context;
        }

        public async Task<bool> AddCartItemAsync(AddCartItemRequest request)
        {
            // Kiểm tra nếu sản phẩm đã tồn tại trong giỏ hàng
            var existingCartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(item => item.ShoppingCartItemId == request.CartId && item.ProductId == request.ProductId);

            if (existingCartItem != null)
            {
                // Nếu sản phẩm đã tồn tại, cập nhật số lượng
                existingCartItem.Quantity += request.Quantity;
            }
            else
            {
                // Nếu không, thêm sản phẩm mới vào giỏ hàng
                var newCartItem = new ShoppingCartItem
                {
                    ShoppingCartItemId = request.CartId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                };
                await _context.ShoppingCartItems.AddAsync(newCartItem);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<CartItemResponse>> GetCartItemsAsync(int cartId)
        {
            // Truy vấn danh sách sản phẩm trong giỏ hàng
            var cartItems = await _context.ShoppingCartItems
                .Where(item => item.UserId == cartId)
                .Include(item => item.Product)
                .Select(item => new CartItemResponse
                {
                    CartItemId = item.ShoppingCartItemId,
                    ProductName = item.Product.Name,
                    //giá trị mặc định 0 sẽ được sử dụng thay thế nếu giá sản phẩm không tồn tại
                    Price = (decimal)(item.Product.Price ?? 0), 
                    Quantity = item.Quantity
                })
                .ToListAsync();

            return cartItems;
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId, int cartId)
        {
            // Tìm sản phẩm trong giỏ hàng cần xóa
            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(item => item.ShoppingCartItemId == cartItemId && item.ShoppingCartItemId == cartId);

            if (cartItem == null) return false;

            _context.ShoppingCartItems.Remove(cartItem);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemQuantityRequest request)
        {
            // Tìm sản phẩm trong giỏ hàng
            var cartItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(item => item.ShoppingCartItemId == request.CartItemId);

            if (cartItem == null) return false;

            // Cập nhật số lượng
            cartItem.Quantity = request.Quantity;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
