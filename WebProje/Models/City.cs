using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Airport>? Airports { get; set;}
    }
}
