using System.ComponentModel.DataAnnotations;

namespace FitSalon.WebUI.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Lütfen parolanızı giriniz")]
        public string Password { get; set; }
    }
}
