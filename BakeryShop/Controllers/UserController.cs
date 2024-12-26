using BakeryShop.Services;
using BakeryShop.Util;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

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
            
            var response = await _apiService.PostAsync<ResponseServices<String>>(apiUrl, request);

            if (response.Success == true)
            {
                return RedirectToAction("Index", "BakeryShop"); // Chuyển hướng đến trang chính

            }
            else
            {

                TempData["ErrorSignIn"] = response.Message ;
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
        public async Task<IActionResult> ValidToken(String token)
        {
            string apiUrl = "https://localhost:7056/api/User/ValidToken?token=" + token;
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
                TempData["SuccessMessage"] = response.Message;
                return RedirectToAction("Index", "BakeryShop");
            }
            else
            {
                TempData["ErrorMessage"] = response.Message;
                return RedirectToAction("ResetPassword", "BakeryShop");

            }
        }









    }
}
