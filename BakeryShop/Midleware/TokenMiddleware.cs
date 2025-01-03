//namespace BakeryShop.Midleware
//{
//    using Azure.Core;
//    using BakeryShop.Services;
//    using BakeryShop.Util;
//    using Microsoft.AspNetCore.Http;
//    using System.Net.Http;
//    using System.Threading.Tasks;

//    public class TokenMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly HttpClient _httpClient;
//        private readonly ApiService _apiService;


//        // Tiêm HttpClient vào middleware thông qua constructor
//        public TokenMiddleware(RequestDelegate next, HttpClient httpClient, ApiService apiService)
//        {
//            _next = next;
//            _httpClient = httpClient;
//            _apiService = apiService;

//        }

//        public async Task InvokeAsync(HttpContext context)
//        {
//            var token = context.Request.Cookies["AuthToken"];

//            if (!string.IsNullOrEmpty(token))
//            {
//                var isValidToken = await ValidateTokenAsync(token);

//                if (isValidToken.Success)
//                {
//                    context.Items["User"] = isValidToken.Data;
//                }
//                else
//                {
//                    context.Response.StatusCode = 401;
//                    await context.Response.WriteAsync("Token không hợp lệ");
//                    return;
//                }
//            }

//            await _next(context);
//        }

//        private async Task<ResponseServices<User>> ValidateTokenAsync(string token)
//        {
//            var apiUrl = "https://localhost:7056/api/User/CheckTokenInCookies";

//            var response = await _apiService.PostAsync<ResponseServices<Object>>(apiUrl, token);


//            if (response.Success)
//            {
//                return response.Data;
//            }

//            return new ResponseServices<User> { Success = false, Message = "Token không hợp lệ" };
//        }
//    }

//}
