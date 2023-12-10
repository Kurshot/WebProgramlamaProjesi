using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class PlaneType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string ModelName { get; set; }
        [Required]
        public int Capacity { get; set; }
        public ICollection<Plane> Planes { get; set; }


    }
}
