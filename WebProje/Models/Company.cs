using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Şirket ismi")]
        public string Name { get; set; }
        public string Logo { get; set; }
        public ICollection<Plane>? Planes { get; set; }
    }
}
