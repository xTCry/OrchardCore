using System.ComponentModel.DataAnnotations;

namespace Module.Pages.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
