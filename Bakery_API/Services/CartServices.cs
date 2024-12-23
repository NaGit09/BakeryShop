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


        // do shopping khong co userId nen ta se lay theo orderId thay vi userId
        //SELECT s.productId, o.orderId, o.totalPrice From ShoppingCartItems s
        //Join Orders o On s.orderId = o.orderId
        //Where userId = 1;
        public async Task<List<CartItem>> GetAllCartItemsAsync(int orderId)
        {
            var cartItems = await _context.ShoppingCartItems
                .Where(c => c.OrderId == orderId)
                .Include(c => c.Product) // Giả sử có mối quan hệ với bảng Product
                .Select(c => new CartItem
                {
                    ShoppingCartItemId = c.ShoppingCartItemId,
                    ProductId = c.ProductId,
                    ProductName = c.Product.Name,
                    Quantity = c.Quantity,
                    Price = c.Product.Price
                })
                .ToListAsync();

            return cartItems;
        }

        public async Task<bool> AddToCartAsync(AddCartRequest request)
        {
            var product = await _context.Products.FindAsync(request.ProductId);
            if (product == null) return false;

            var existingItem = await _context.ShoppingCartItems
                .FirstOrDefaultAsync(c => c.ProductId == request.ProductId && c.OrderId == request.OrderId);

            if (existingItem != null)
            {
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                var cartItem = new ShoppingCartItem
                {
                    ProductId = request.ProductId,
                    OrderId = request.OrderId,
                    Quantity = request.Quantity
                };
                await _context.ShoppingCartItems.AddAsync(cartItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemQuantityRequest request)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(request.ShoppingCartItemId);
            if (cartItem == null) return false;

            cartItem.Quantity = request.Quantity;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveFromCartAsync(int shoppingCartItemId)
        {
            var cartItem = await _context.ShoppingCartItems.FindAsync(shoppingCartItemId);
            if (cartItem == null) return false;

            _context.ShoppingCartItems.Remove(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }

       
    }
}
