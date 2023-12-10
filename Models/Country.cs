using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Country
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(35)]
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
