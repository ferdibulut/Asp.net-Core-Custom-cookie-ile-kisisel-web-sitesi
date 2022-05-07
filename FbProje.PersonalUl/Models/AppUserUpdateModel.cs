using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FbProje.PersonalUl.Models
{
    public class AppUserUpdateModel
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="İsim gereklidir")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad gereklidir")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres gereklidir")]
        public string Address { get; set; }
        [Required(ErrorMessage ="Email gereklidir")]
        public string Email { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Telefon gereklidir")]
        public string PhoneNumber { get; set; }
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = "Ön yazı  gereklidir")]
        public string ShortDescription { get; set; }
    }
}
