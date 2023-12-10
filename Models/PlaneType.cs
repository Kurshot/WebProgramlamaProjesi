using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class PlaneType
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Plane> Planes { get; set; }


    }
}
