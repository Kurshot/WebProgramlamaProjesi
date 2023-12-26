using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class User : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Kullanıcı adı")]
        public string Name { get; set; }
        [Display(Name = "Kullanıcı soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Mail adresi")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public bool Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime birthdate { get; set; }
        public ICollection<Ticket>? Ticket { get; set; }
    }
}
