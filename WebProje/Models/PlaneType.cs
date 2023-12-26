using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class PlaneType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Model ismi")]
        public string modelName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Plane>? Planes { get; set;}
    }
}
