using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Format")]
        public string Email { get; set; }
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password Must be atleast 8 Characters")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Confirm Password dosn`t match Password")]
        [Required(ErrorMessage = "Confirm Password is required")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Is Active is required")]
        public bool IsActive
        {
            get; set;
        }
    }
}
