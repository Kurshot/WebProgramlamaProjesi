using System.ComponentModel.DataAnnotations;

namespace H12Auth2C.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Ülke Adı")]
        public string Name { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
