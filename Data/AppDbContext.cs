using Microsoft.EntityFrameworkCore;
using Web_Programlama_Dersi_Proje_Ödevi.Models;

namespace Web_Programlama_Dersi_Proje_Ödevi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products{ get; set; }

    }
}
