using Bakery_API.DTO;
using Bakery_API.Interfaces;
using Bakery_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bakery_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;

        public UserController(IUser user) { 
        
            _user = user;    // Dependency Injection (DI)
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromForm] UserRequest request)
        {
            var response = _user.SignIn(request);

            if (response.Success)
            {
                return Ok(new
                {
                    status = response.Success,
                    message = response.Message,
                    data = response.Data
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
