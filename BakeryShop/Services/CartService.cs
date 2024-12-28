using Bakery_API.Models;
using BakeryShop.Util;
using System.Text.Json;

namespace BakeryShop.Services
{
    public class CartService
    {
        private readonly HttpClient _httpClient;

        public CartService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("BakeryApi");
        }

        public async Task<List<CartItemResponse>> GetCartItemsAsync(int cartId)
        {
            var response = await _httpClient.GetAsync($"Cart/{cartId}");
            response.EnsureSuccessStatusCode();
            var cartItems = await response.Content.ReadFromJsonAsync<List<CartItemResponse>>();
            return cartItems ?? new List<CartItemResponse>();
        }

        public async Task<bool> AddCartItemAsync(AddCartItemRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("Cart", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateCartItemQuantityAsync(UpdateCartItemQuantityRequest request)
        {
            var response = await _httpClient.PutAsJsonAsync("Cart", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveCartItemAsync(int cartItemId, int cartId)
        {
            var response = await _httpClient.DeleteAsync($"Cart/{cartItemId}/{cartId}");
            return response.IsSuccessStatusCode;
        }
    }
}

