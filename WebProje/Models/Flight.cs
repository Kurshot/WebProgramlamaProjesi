using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime arrivalTime { get; set; }
        public int PlaneId { get; set; }
        public Plane Plane { get; set; }
        public float price { get; set; }
        public DateTime DateTime { get; set; }
        public int? departurePlaceId { get; set; }
        public Airport departurePlace { get; set; }
        public int? arrivalPlaceId { get; set; }
        public Airport arrivalPlace { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
