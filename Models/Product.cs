using System.ComponentModel.DataAnnotations;

namespace Web_Programlama_Dersi_Proje_Ödevi.Models
{
    public class Product 
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }   
    }
}
