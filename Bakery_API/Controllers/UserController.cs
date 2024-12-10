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
        private readonly TokenServices _tokenServices;


        public UserController(IUser user, TokenServices tokenServices) { 
        
            _user = user;
            _tokenServices = tokenServices;


        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UserRequest request)
        {
            var response = _user.SignIn(request);

            if (response.Success)
            {
                if (response.Data == null)
                {
                    return BadRequest(new
                    {
                        status = false,
                        message = "Invalid credentials. User not found."
                    });
                }
             
                return Ok(new
                {
                    status = response.Success,
                    message = response.Message,
                    data = _tokenServices.GenerateToken(response.Data)
                });
            }
            else
            {
                return BadRequest(new
                {
                    status = response.Success,
                    message = response.Message
                });
            }
        }



    }
}
