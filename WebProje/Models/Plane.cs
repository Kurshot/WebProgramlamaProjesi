using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Plane
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Company Company { get; set; }
        public PlaneType Type { get; set; }
        public Flight Flight { get; set; }
    }
}
