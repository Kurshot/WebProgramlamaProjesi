using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace WebProje.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Display(Name = "Kalkış Yeri")]
        public int DeparturePlaceId { get; set; }
        
        [Display(Name = "Varış Yeri")]
        public int ArrivalPlaceId { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public float Price { get; set; }
        [NotMapped]
        public Airport? Airport { get; set; }
        public ICollection<Plane>? Planes { get; set; }
    }
}
