using System.Net.Http;

namespace BakeryShop.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<List<T>> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadFromJsonAsync<List<T>>();
            return data ?? new List<T>();
        }
        public async Task<T> GetAsyncToken<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<List<Product>> GetAsync2<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            // Đọc toàn bộ JSON trả về
            var responseData = await response.Content.ReadFromJsonAsync<ResponseServices<List<Product>>>();
            // Trả về dữ liệu từ thuộc tính 'Data', hoặc danh sách rỗng nếu không có dữ liệu
            return responseData?.Data ?? new List<Product>();
        }
        public async Task<T?> PostAsync2<T>(string url, object payload)
        {
            var response = await _httpClient.PostAsJsonAsync(url, payload);
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
