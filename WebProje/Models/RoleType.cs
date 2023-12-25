using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class RoleType
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Yetki seviyesi")]
        public string roleName { get; set; }
        public ICollection<Rolles>? rolles { get; set; }
    }
}
