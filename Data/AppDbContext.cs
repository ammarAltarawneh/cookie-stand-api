using cookie_stand_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) { }

        public DbSet<CookieStand> cookieStands { get; set; }

        public DbSet<HourlySales> hourlySales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            var cookieStands = new List<CookieStand>
        {
            new CookieStand
            {
                Id=1,
                Location = "Barcelona",
                Description = "bla bla",
                MinimumCustomersPerHour = 2,
                MaximumCustomersPerHour = 4,
                AverageCookiesPerSale = 2.5,
                Owner = "Ali"
            },
            new CookieStand
            {
                Id=2,
                Location = "Irbid",
                Description = "description2",
                MinimumCustomersPerHour = 3,
                MaximumCustomersPerHour = 7,
                AverageCookiesPerSale = 1.75,
                Owner = "Salma"
            }
        };

            // Add the data to the context
            modelBuilder.Entity<CookieStand>().HasData(cookieStands);

            modelBuilder.Entity<CookieStand>()
     .HasKey(c => c.Id);
        }

    }
}
