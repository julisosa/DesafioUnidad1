using System.ComponentModel.DataAnnotations;

namespace DesafiosAPI.ViewModels.Auth
{
    public class Login
    {
        [Required]
        [MinLength(6)]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
