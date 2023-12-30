using System.ComponentModel.DataAnnotations;
namespace H12Auth2C.Models
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int PlaneTypeId { get; set; }
        [Display(Name = "Compamy Name")]
        public Company? Company { get; set; }
        [Display(Name = "Plane Type")]
        public PlaneType? PlaneType { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
