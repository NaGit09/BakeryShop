using Bakery_API.DTO;
using Bakery_API.Models;

namespace BakeryShop.Services
{
    public class CartService
    {
        private readonly ApiService _apiService;
        private readonly string _baseUrl = "https://localhost:7056/api/Cart"; // URL của API

        public CartService(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<List<ShoppingCartItem>> GetCartItemsAsync(int userId)
        {
            userId = 1;
            string url = $"{_baseUrl}/userId?userID={userId}";
            return await _apiService.GetAsync<List<ShoppingCartItem>>(url);
        }

        public async Task AddToCartAsync(AddCartRequest request)
        {
            string url = $"{_baseUrl}/add";
            await _apiService.PostAsync<object>(url, request);
        }

        public async Task UpdateCartItemAsync(UpdateCartItemQuantityRequest request)
        {
            string url = $"{_baseUrl}/update";
            await _apiService.PutAsync<object>(url, request);
        }

        public async Task RemoveCartItemAsync(int cartItemId)
        {
            string url = $"{_baseUrl}/remove/{cartItemId}";
            await _apiService.DeleteAsync(url);
        }
    }
}

