using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
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
