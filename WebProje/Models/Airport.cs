using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Havalimanı Adı")]
        public string AirportName { get; set; }
        [Display(Name = "Havalimanı Kodu")]
        public string AirportCode { get; set; }
        public int CityId { get; set; }
        public City? City { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public ICollection<Flight>? Flights1 { get; set; }
    }
}
