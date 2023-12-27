using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace H12Auth2C.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Şirket ismi")]
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Plane>? Planes { get; set; }
    }
}
