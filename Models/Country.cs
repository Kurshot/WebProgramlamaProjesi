using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
