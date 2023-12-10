using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }
        public string AirportName { get; set; }
        public string AirportCode { get; set; }
        public virtual City City { get; set; }
        public ICollection<Flight> Flights { get; set; }

 
    }
}
