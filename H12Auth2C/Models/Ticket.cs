using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Ticket Holder")]
        public string UserId { get; set; }
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
        public UserDetails? User { get; set; }
    }
}
