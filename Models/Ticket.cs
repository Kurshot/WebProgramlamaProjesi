using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual User TicketHolder { get; set; }
        public bool TicketType { get; set; }
        public float TicketPrice { get; set; }
    }
}
