using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class LoginValidation 
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String? Gmail { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }
        //[Required(ErrorMessage = "You must agree to the terms and conditions")]
        //[Display(Name = "I agree to the terms and conditions")]
        //public bool SavePassWord { get; set; }
    }
}
