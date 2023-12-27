using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class UserDetails:IdentityUser
    {
        [Display(Name ="Kullanıcı Adı")]
        public string UserAd { get; set; }
        [Display(Name = "Kullanıcı Soyadı")]
        public string UserSoyad { get; set; }
        [Display(Name ="Cinsiyet")]
        public bool Gender { get; set; }

        [Display(Name ="Doğum tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime birthdate { get; set; }
        public ICollection<Ticket>? Ticket { get; set; }
    }
}
