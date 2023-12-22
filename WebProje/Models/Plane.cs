using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Marka Adı")]
        public string BrandName { get; set; }
        public int CompanyId { get; set; }
        public int PlaneTypeId { get; set; }
        public Company Company { get; set; }
        public PlaneType PlaneType { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
