using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class User
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
        [Display(Name = "Telefon numarası")]
        public string phoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public bool Gender { get; set; }
        public DateTime birthdate { get; set; }
        public ICollection<Ticket>? Ticket { get; set; }
    }
}
