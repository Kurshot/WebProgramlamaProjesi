using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Plane
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Company Company { get; set; }
        public virtual PlaneType Type { get; set; }
        public ICollection<Flight> Flights { get; set; }

    }
}
