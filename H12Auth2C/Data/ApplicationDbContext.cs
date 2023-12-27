using H12Auth2C.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace H12Auth2C.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Flight>().HasOne(x => x.departurePlace)
                .WithMany(y => y.Flights)
                .HasForeignKey(z => z.departurePlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Flight>().HasOne(x => x.arrivalPlace)
                .WithMany(y => y.Flights1)
                .HasForeignKey(z => z.arrivalPlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }
        public DbSet<UserDetails> Users { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
Database=airlines;Trusted_Connection=True;");
        }
    }
}