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

        public async Task AddCartAsync(AddCartRequest rq)
        {
            // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng chưa
            var cartItem = await _context.ShoppingCartItems.FirstOrDefaultAsync(x => x.ProductId == rq.ProductId && x.OrderId == rq.OrderId);
            if (cartItem != null)
            {
                // Nếu sản phẩm đã tồn tại thì cập nhật số lượng
                cartItem.Quantity += rq.Quantity;
                await _context.SaveChangesAsync();
                return;
            }
            else 
            {
                // Nếu sản phẩm chưa tồn tại thì thêm mới
                var item = new ShoppingCartItem
                {
                    ProductId = rq.ProductId,
                    OrderId = rq.OrderId,
                    Quantity = rq.Quantity
                };
                await _context.ShoppingCartItems.AddAsync(item);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<ShoppingCartItem>> GetCartItemsAsync(int userId)
        {
            var cartItems = await _context.ShoppingCartItems
            .Where(cartItem => cartItem.Order.UserId == userId) // Liên kết qua Order để lấy UserId
            .Include(cartItem => cartItem.Product) // Bao gồm thông tin sản phẩm
            .Include(cartItem => cartItem.Order) // Bao gồm thông tin đơn hàng
            .ToListAsync();

            return cartItems;
        }

        public async Task<bool> RemoveFromCartAsync(int cartItemId)
        {
            // Tìm sản phẩm trong giỏ hàng theo ID
            var cartItem = await _context.ShoppingCartItems.FindAsync(cartItemId);

            if (cartItem == null)
            {
                return false;
            }

            // Xóa sản phẩm khỏi giỏ hàng
            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            return true; 
        }

        public async Task<bool> UpdateCartItemQuantityAsync(int cartItemId, int quantity)
        {
            // Tìm sản phẩm trong giỏ hàng theo ID
            var cartItem = await _context.ShoppingCartItems.FindAsync(cartItemId);

            if (cartItem == null)
            {
                return false;
            }

            if (quantity <= 0)
            {
                return false;
            }

            // Cập nhật số lượng
            cartItem.Quantity = quantity;
            await _context.SaveChangesAsync();

            return true; 
        }
    }
}
