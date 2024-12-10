using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BakeryShop.Util
{
    public class RegisterValidation
    {
        [Required(ErrorMessage = "Enter your first name")]
        [DataType(DataType.Text)]
        public String? FirstName { get; set; }
        [Required(ErrorMessage = "Enter your last name")]
        [DataType(DataType.Text)]
        public String? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public String? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public String? Password { get; set; }
        [Required]
        public int BirthYear { get; set; }
        [Required]
        public int BirthMonth { get; set; }
        [Required]
        public int BirthDay { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Select your gender")]
        public String? Gender { get; set; }
        public List<SelectListItem> genders { get; set; }
        [Required(ErrorMessage ="Please agree with Assurance")]
        public bool agree { get; set; }
    }
    }
