using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string CityName { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<Airport> Airports { get; set; }

    }
}
