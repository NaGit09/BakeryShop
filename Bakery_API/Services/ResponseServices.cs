namespace Bakery_API.Services
{
    public class ResponseServices<T>
    {
        public T Data { get; set; }  // Dữ liệu tổng quát
        public bool Success { get; set; } // Trạng thái có thành công hay không
        public string Message { get; set; } // Thông báo
    }
}
