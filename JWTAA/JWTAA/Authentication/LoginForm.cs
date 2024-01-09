using System.ComponentModel.DataAnnotations;

namespace JWTAA.Authentication
{
    public class LoginForm
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
