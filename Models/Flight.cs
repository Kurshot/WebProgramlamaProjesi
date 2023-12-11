using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Airport departurePlaceId { get; set; }
        public Airport arrivalPlaceId { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public float Price { get; set; }
        public ICollection<Plane> Planes { get; set; }

    }
}
