using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class City
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }
        public  Country Country { get; set; }
        public ICollection<Airport> Airports { get; set; }

    }
}
