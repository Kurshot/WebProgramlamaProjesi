using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace H12Auth2C.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "City Name")]
        public string Name { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        public Country? Country { get; set; }
        public ICollection<Airport>? Airports { get; set; }
    }
}
