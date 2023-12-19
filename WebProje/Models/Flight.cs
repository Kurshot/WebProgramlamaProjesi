using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebProje.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Kalkış Yeri")]
        public Airport? departurePlaceId { get; set; }
        [Display(Name = "Varış Yeri")]
        public Airport? arrivalPlaceId { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public float Price { get; set; }
        public ICollection<Plane> Planes { get; set; }
    }
}
