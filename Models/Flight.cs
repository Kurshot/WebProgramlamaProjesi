using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Flight
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Plane Plane { get; set; }

        [ForeignKey("InsuranceId")]
        public int DeparturePlaceId { get; set; }
        
        public virtual Airport ArrivalPlace { get; set; }
        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }
        public float Price { get; set; }

    }
}
