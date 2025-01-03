﻿using Azure;
using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Bakery_API.Models;
using Bakery_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Bakery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;


        public UserController(IUser user, TokenServices tokenServices)
        {

            _user = user;


        }


        [HttpPost("SignIn")]
        public IActionResult SignIn([FromBody] UserSignInRequest request)
        {

            var response = _user.SignIn(request);

            if (response.Success)
            {
                return Ok(new ResponseServices<User>
                {
                    Data = response.Data,
                    Message = response.Message,
                    Success = response.Success,


                });

            }
            else
            {
                return Ok(new ResponseServices<User>
                {
                    Data = response.Data,
                    Message = response.Message,
                    Success = response.Success,


                });

            }

        }


        [HttpPost("SignUp")]
        public IActionResult SignUp([FromBody] UserSignUpRequest request)
        {
            var user = _user.SignUp(request);

            if (user.Success)
            {
                return Ok(new ResponseServices<User>
                {

                    Message = user.Message,
                    Success = user.Success,


                });
            }
            else
            {
                return Ok(new ResponseServices<User>
                {

                    Message = user.Message,
                    Success = user.Success,


                });
            }


        }




        [HttpPost("CheckOTP")]

        public IActionResult CheckOTP([FromBody] CheckOTPRequest checkOTPRequest)
        {
            var isValid = _user.CheckNumberOTP(checkOTPRequest);

            if (isValid.Success)
            {
                return Ok(new ResponseServices<User>
                {

                    Message = isValid.Message,
                    Success = isValid.Success,


                });
            }
            else
            {
                return Ok(new ResponseServices<User>
                {

                    Message = isValid.Message,
                    Success = isValid.Success,


                });
            }

        }

        [HttpPost("CheckMailLogin")]
        public IActionResult CheckMailLogin([FromBody] string email)
        {
            var isValid = _user.CheckMailLogin(email);

            if (isValid.Success)
            {
                return Ok(new ResponseServices<string>
                {
                    Success = isValid.Success
                });
            }

            return Ok(new ResponseServices<string>
            {
                Success = isValid.Success
            });
        }


        [HttpPost("CheckMail")]

        public IActionResult CheckMail([FromBody] ForgotPasswordValidation forgotPasswordValidation)
        {
            var check = _user.CheckMail(forgotPasswordValidation);
            if (check.Success)
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });
            }
            else
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });

            }

        }


        [HttpGet("ValidTokenInMail")]
        public IActionResult ValidTokenInMail(String token)
        {
            var check = _user.ValidTokenInMail(token);
            if (check.Success)
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });
            }
            else
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });

            }
        }
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword(ResetPassword resetPassword)
        {
            var check = _user.ResetPassword(resetPassword);

            if (check.Success)
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });
            }
            else
            {
                return Ok(new ResponseServices<String>
                {
                    Success = check.Success,
                    Message = check.Message,

                });

            }


        }

        [HttpPost("CheckTokenInCookies")]
        public IActionResult CheckTokenInCookies(string token)
        {
            var checkToken = _user.CheckTokenInCookies(token);

            if (checkToken.Success)
            {
                return Ok(new ResponseServices<User>
                {
                    Success = checkToken.Success,
                    Message = checkToken.Message,
                    Data = checkToken.Data

                });

            }
            return Ok(new ResponseServices<User>
            {
                Success = checkToken.Success,
                Message = checkToken.Message,
                Data = checkToken.Data

            });
        }



    }



}



