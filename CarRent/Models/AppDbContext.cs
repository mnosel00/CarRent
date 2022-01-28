using Microsoft.EntityFrameworkCore;
using CarRent.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CarRent.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Card { get; set; }

        public DbSet<CarRent.Models.CreateViewModel> CreateViewModel { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Typ> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.CompanySeed();
            builder.TypSeed();
        }



    }
}
