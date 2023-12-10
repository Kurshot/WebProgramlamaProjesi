using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
