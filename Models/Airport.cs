using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Airport
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string AirportName { get; set; }
        [Required]
        [MaxLength(30)]
        public string AirportCode { get; set; }
        [Required]
        [MaxLength(30)]
        public virtual City City { get; set; }
        public ICollection<Flight> Flights { get; set; }

 
    }
}
