using System.Net.Http;
using System.Text.Json;
using System.Text;

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

        //public async Task<T?> GetAsync<T>(string url)
        //{
        //    try
        //    {
        //        var response = await _httpClient.GetAsync(url);
        //        response.EnsureSuccessStatusCode();

        //        var jsonString = await response.Content.ReadAsStringAsync(); // Log dữ liệu trả về
        //        Console.WriteLine("JSON Response: " + jsonString);

        //        var data = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true // Bỏ qua phân biệt hoa thường
        //        });
        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception($"Lỗi khi gọi API GET: {ex.Message}");
        //    }
        //}

        public async Task<T?> PostAsync<T>(string url, object payload)
        {
            var response = await _httpClient.PostAsJsonAsync(url, payload);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }
        public async Task<T?> PutAsync<T>(string url, object payload)
        {
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
