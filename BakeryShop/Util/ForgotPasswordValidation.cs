using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class ForgotPasswordValidation
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
