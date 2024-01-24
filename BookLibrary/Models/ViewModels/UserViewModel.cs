using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Models.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
