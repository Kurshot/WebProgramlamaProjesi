using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class UserDetails:IdentityUser
    {
        [Display(Name ="Name")]
        public string UserAd { get; set; }
        [Display(Name = "Last Name")]
        public string UserSoyad { get; set; }
        [Display(Name ="Gender")]
        public bool Gender { get; set; }
        
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime birthdate { get; set; }
        public ICollection<Ticket>? Ticket { get; set; }
    }
}
