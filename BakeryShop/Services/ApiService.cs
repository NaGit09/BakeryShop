using Azure;
using BakeryShop.Areas.Admin.ViewModels;
using System.Net.Http;
using System.Text.RegularExpressions;


namespace BakeryShop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var responseData = await response.Content.ReadFromJsonAsync<ResponseServices<List<Product>>>();
            return responseData?.Data ?? new List<Product>();
        }


        public async Task<List<Product>> GetAllProduct(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<ResponseServices<List<Product>>>();
            return data?.Data ?? new List<Product>();
        }


        public async Task<ResponseServices<Product>> AddProductAsync(string url, AddProductVM productVM)
        {
            var response = await _httpClient.PostAsJsonAsync(url, productVM);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ResponseServices<Product>>();
        }

        public async Task<List<ProductCategory>> GetCategoriesAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<ResponseServices<List<ProductCategory>>>();
            return data?.Data ?? new List<ProductCategory>();
        }

        public async Task<List<Group>> GetGroupsAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadFromJsonAsync<ResponseServices<List<Group>>>();
            return data?.Data ?? new List<Group>();
        }


        public async Task<T> GetAsyncToken<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<T?> PostAsync<T>(string url, object payload)
        {
            var response = await _httpClient.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }

}
