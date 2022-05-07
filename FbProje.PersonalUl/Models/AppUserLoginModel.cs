using System.ComponentModel.DataAnnotations;

namespace FbProje.PersonalUl.Models
{
    public class AppUserLoginModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Gereklidir")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Gereklidir")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
