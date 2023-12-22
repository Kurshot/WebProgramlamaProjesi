using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Şirket Adı")]
        public string Name { get; set; }
        public ICollection<City>? Cities { get; set; }
    }
}
