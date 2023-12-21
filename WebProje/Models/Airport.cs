using static Humanizer.In;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
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
        public int CityId { get; set; }
        [NotMapped]
        public ICollection<Flight> ?Flights { get; set; }
    }
}
