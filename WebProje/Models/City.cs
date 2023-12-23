using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Şehir Adı")]
        public string Name { get; set; }
        [Display(Name="Ülke Adı:")]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public ICollection<Airport>? Airports { get; set;}
    }
}
