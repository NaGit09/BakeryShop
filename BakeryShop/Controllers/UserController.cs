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

        //tetstttttttt



    }
}
