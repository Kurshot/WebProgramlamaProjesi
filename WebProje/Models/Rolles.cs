using System.ComponentModel.DataAnnotations;

namespace WebProje.Models
{
    public class Rolles
    {
        [Key]
        public int Id { get; set; }
        public int roleTypeId { get; set;}
        public int UserId { get; set; }
        public RoleType? RoleType { get; set; }
        public User? User { get; set; }
    }
}
