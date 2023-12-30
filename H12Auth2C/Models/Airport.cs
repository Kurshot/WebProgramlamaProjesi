using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class Airport
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Airport Name")]
        public string AirportName { get; set; }
        [Display(Name = "Airport Code")]
        public string AirportCode { get; set; }
        public int CityId { get; set; }
        [Display(Name = "City")]
        public City? City { get; set; }
        public ICollection<Flight>? Flights { get; set; }
        public ICollection<Flight>? Flights1 { get; set; }
    }
}
