using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public sealed class RegisterViewModel
    {
        [Required(ErrorMessage = "Empty email.")]
        [Display(Name = "Enter email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Wrond email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Empty password.")]
        [Display(Name = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Passwords don't match.")]
        public string ConfirmPassword { get; set; }
    }
}
