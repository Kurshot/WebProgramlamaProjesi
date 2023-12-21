using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace WebProje.Models
{
    public class City
    { 
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public ICollection<Airport> Airports { get; set; }

    }
}
