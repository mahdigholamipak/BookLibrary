using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password confirmation is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Do not match")]
        public string ConfirmPassword { get; set; }
    }
}
