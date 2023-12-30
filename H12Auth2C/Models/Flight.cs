using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using System.Numerics;

namespace H12Auth2C.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime departureTime { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime arrivalTime { get; set; }
        [Display(Name = "Plane Type")]
        public int PlaneId { get; set; }
        public Plane? Plane { get; set; }
        [Display(Name = "Ticket Price")]
        public float price { get; set; }
        [Display(Name = "Departure Place")]
        public int? departurePlaceId { get; set; }
        public Airport? departurePlace { get; set; }
        [Display(Name = "Arrival Place")]
        public int? arrivalPlaceId { get; set; }
        public Airport? arrivalPlace { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
