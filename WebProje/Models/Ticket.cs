using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public bool ticketType { get; set; }
        public int UserId { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }
        public User User { get; set; }
    }
}
