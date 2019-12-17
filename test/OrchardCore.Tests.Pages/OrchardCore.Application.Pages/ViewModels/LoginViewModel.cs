using System.ComponentModel.DataAnnotations;

namespace OrchardCore.Application.Pages.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The Username field is required.")]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
