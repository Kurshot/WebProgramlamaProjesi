using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace WebProje.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Plane> Planes { get; set; }
    }
}
