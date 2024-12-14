using System.ComponentModel.DataAnnotations;

namespace Bakery_API.DTO
{
    public class UserSignInRequest
    {   
        public string Gmail { get; set; }

        public string Password { get; set; }
    }
}
