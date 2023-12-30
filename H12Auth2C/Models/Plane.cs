using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace H12Auth2C.Models
{
    public class Plane
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Company")]
        public int CompanyId { get; set; }
        [Display(Name = "Plane Tyoe")]
        public int PlaneTypeId { get; set; }
        public Company? Company { get; set; }
        public PlaneType? PlaneType { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
