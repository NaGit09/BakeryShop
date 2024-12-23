using Bakery_API.Models;
using BakeryShop.Util;

namespace BakeryShop.Services
{
    public class CartService
    {
        private readonly ApiService _apiService;

        public CartService(ApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task<List<CartItem>> GetAllCartItemsAsync(int orderId)
        {
            var apiUrl = $"https://localhost:7056/api/cart/all/{orderId}"; // Thay URL phù hợp
            return await _apiService.GetAsync<List<CartItem>>(apiUrl) ?? new List<CartItem>();
            //return await _apiService.GetAsync<List<CartItem>>($"cart/all/{orderId}") ?? new List<CartItem>();
        }

        public async Task<bool> AddToCartAsync(UpdateCartQuantity request)
        {
            var response = await _apiService.PostAsync<ResponseServices<bool>>("cart/add", request);
            return response?.Success ?? false;
        }

        public async Task<bool> UpdateCartItemQuantityAsync(UpdateCartQuantity request)
        {
            var response = await _apiService.PutAsync<ResponseServices<bool>>("cart/update", request);
            return response?.Success ?? false;
        }

        public async Task<bool> RemoveFromCartAsync(int cartItemId)
        {
            try
            {
                await _apiService.DeleteAsync($"cart/remove/{cartItemId}");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

