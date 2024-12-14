using Azure;
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
                return Ok(new ResponseServices<String>
                {
                    Data = response.Data,
                    Message = response.Message,
                    Success = response.Success,


                });

            }
            else
            {
                return Ok(new ResponseServices<String>
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

    }
}



