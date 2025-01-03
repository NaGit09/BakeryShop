using Azure.Core;
using BakeryShop.Services;
using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Text.Json;

namespace BakeryShop.Controllers
{
    public class UserController : Controller
    {
        private readonly ApiService _apiService;

        public UserController(ApiService apiService)
        {

            _apiService = apiService;


        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterValidation request)
        {
            string apiUrl = "https://localhost:7056/api/User/SignUp";


            var response = await _apiService.PostAsync<ResponseServices<Object>>(apiUrl, request);

            if (response.Success)
            {
                return RedirectToAction("ConfirmOTP", "BakeryShop"); // Chuyển hướng đến trang chính

            }
            else
            {

                TempData["ErrorSignUp"] = response.Message;
                return RedirectToAction("Register", "BakeryShop"); // Chuyển hướng về trang đăng nhập

            }



        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginValidation request)
        {
           
            string apiUrl = "https://localhost:7056/api/User/SignIn";

            var response = await _apiService.PostAsync<ResponseServices<User>>(apiUrl, request);

            if (response.Success == true)
            {
                if (!string.IsNullOrEmpty(response.Message))
                {
                    var cookieOptions = new CookieOptions
                    {
                        HttpOnly = true,    // Không cho phép JavaScript truy cập cookie này
                        Secure = true,      // Chỉ gửi cookie qua HTTPS
                        SameSite = SameSiteMode.Strict  // Cấu hình SameSite để bảo vệ khỏi CSRF
                    };

                    // Lưu token vào cookie
                    HttpContext.Response.Cookies.Append("AuthToken", response.Message, cookieOptions);
                }



                return RedirectToAction("Index", "BakeryShop"); // Chuyển hướng đến trang chính

            }
            else
            {

                TempData["ErrorSignIn"] = response.Message;
                return RedirectToAction("login", "BakeryShop"); // Chuyển hướng về trang đăng nhập

            }

        }

        [HttpPost]
        public async Task<IActionResult> ConfirmOTP(RequestOTPValidation request)
        {
            string apiUrl = "https://localhost:7056/api/User/CheckOTP";

            try
            {
                var response = await _apiService.PostAsync<ResponseServices<Object>>(apiUrl, request);

                if (response.Success)
                {
                    return RedirectToAction("login", "BakeryShop");
                }
                else
                {
                    TempData["Error"] = "Tài khoản và mật khẩu không đúng";
                    return RedirectToAction("Register", "BakeryShop");
                }


            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "BakeryShop");

            }


        }
        [HttpPost]
        public async Task<IActionResult> CheckMail(ForgotPasswordValidation mail)
        {
            string apiUrl = "https://localhost:7056/api/User/CheckMail";

            var response = await _apiService.PostAsync<ResponseServices<String>>(apiUrl, mail);

            if (response.Success)
            {

                TempData["StatusMail"] = response.Message;
                return RedirectToAction("ForgotPassword", "BakeryShop");
            }
            else
            {

                TempData["StatusMail"] = response.Message;
                return RedirectToAction("ForgotPassword", "BakeryShop");

            }
        }

        [HttpGet]
        public async Task<IActionResult> ValidTokenInMail(String token)
        {
            string apiUrl = "https://localhost:7056/api/User/ValidTokenInMail?token=" + token;
            var response = await _apiService.GetAsyncToken<ResponseServices<String>>(apiUrl);

            if (response.Success)
            {

                TempData["Status"] = response.Message;
                return RedirectToAction("ResetPassword", "BakeryShop");
            }
            else
            {

                TempData["Status"] = response.Message;
                return RedirectToAction("ForgotPassword", "BakeryShop");

            }


        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
        {
            string apiUrl = "https://localhost:7056/api/User/ResetPassword";
            var response = await _apiService.PostAsync<ResponseServices<String>>(apiUrl, resetPassword);

            if (response.Success)
            {
                TempData["SwalMessage"] = response.Message; // Thông báo thành công
                TempData["SwalType"] = "success"; // Loại thông báo
                return RedirectToAction("ResetPassword", "BakeryShop");
            }
            else
            {
                TempData["SwalMessage"] = response.Message; // Thông báo lỗi
                TempData["SwalType"] = "error"; // Loại thông báo
                return RedirectToAction("ResetPassword", "BakeryShop");
            }
        }




        public IActionResult Logout()
        {
            // Xóa cookie chứa access token
            HttpContext.Response.Cookies.Delete("AuthToken");

            // Chuyển hướng người dùng về trang đăng nhập (hoặc trang khác nếu cần)
            return RedirectToAction("Index", "BakeryShop");
        }







    }
}
