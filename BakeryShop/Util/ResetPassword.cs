using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class ResetPassword
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận mật khẩu.")]
        [Compare("Password", ErrorMessage = "Mật khẩu và xác nhận mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }
    }
}
