using System.ComponentModel.DataAnnotations;

namespace Bakery_API.DTO
{
    public class UserRequest
    {
        [Required]
        [EmailAddress]
        public string Gmail { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
