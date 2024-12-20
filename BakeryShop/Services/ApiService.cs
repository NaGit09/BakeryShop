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

            // Đọc toàn bộ JSON trả về
            var responseData = await response.Content.ReadFromJsonAsync<ResponseServices<List<T>>>();

            // Trả về dữ liệu từ thuộc tính 'Data', hoặc danh sách rỗng nếu không có dữ liệu
            return responseData?.Data ?? new List<T>();
        }


        public async Task<T?> PostAsync<T>(string url, object payload)
        {
            var response = await _httpClient.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
