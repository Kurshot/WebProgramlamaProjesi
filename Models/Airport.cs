using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Airport
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string AirportName { get; set; }
        [Required]
        [MaxLength(5)]
        public string AirportCode { get; set; }
        public virtual City City { get; set; }
        public ICollection<Flight> Flights { get; set; }

 
    }
}
