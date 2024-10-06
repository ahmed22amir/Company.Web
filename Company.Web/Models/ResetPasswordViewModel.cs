using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password Must be atleast 8 Characters")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Confirm Password dosn`t match Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
    }
}
