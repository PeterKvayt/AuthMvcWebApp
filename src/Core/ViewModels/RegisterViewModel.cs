using System.ComponentModel.DataAnnotations;

namespace Core.ViewModels
{
    public sealed class RegisterViewModel
    {
        [Required(ErrorMessage = "Empty email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Empty password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wrong password.")]
        public string ConfirmPassword { get; set; }
    }
}
