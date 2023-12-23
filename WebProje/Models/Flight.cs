using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Kalkış Zamanı")]
        public DateTime departureTime { get; set; }
        [Display(Name = "Varış Zamanı")]
        public DateTime arrivalTime { get; set; }
        [Display(Name = "Uçak Türü")]
        public int PlaneId { get; set; }
        public Plane? Plane { get; set; }
        [Display(Name = "Bilet Fiyatı")]
        public float price { get; set; }
        [Display(Name = "Kalkış Yeri")]
        public int? departurePlaceId { get; set; }
        public Airport? departurePlace { get; set; }
        [Display(Name = "Varış Yeri")]
        public int? arrivalPlaceId { get; set; }
        public Airport? arrivalPlace { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
