using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class LoginValidation
    {
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email không đúng định dạng")]
        [EmailAddress(ErrorMessage = "Vui lòng nhập địa chỉ email hợp lệ")]
        public string? Gmail { get; set; }

        [Required(ErrorMessage = "Password không được để trống")]
        [DataType(DataType.Password, ErrorMessage = "Password không đúng định dạng")]
        [MinLength(6, ErrorMessage = "Password phải có ít nhất 6 ký tự")]
        public string? Password { get; set; }

    }
}
