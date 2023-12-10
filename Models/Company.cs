using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Plane> Planes { get; set; }

    }
}
