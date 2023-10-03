using cookie_stand_api.Models;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions options) : base(options) { }

        public DbSet<CookieStand> cookieStands { get; set; }

        //public DbSet<HourlySales> hourlySales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {          
            modelBuilder.Entity<CookieStand>().HasData(
            new CookieStand() { Id = 1, Location = "Barcelona", Description = "", MinimumCustomersPerHour = 3, MaximumCustomersPerHour = 7, AverageCookiesPerSale = 2.5, Owner = null}
               );

            modelBuilder.Entity<CookieStand>().HasKey(c => c.Id);
        

            //modelBuilder.Entity<HourlySales>().HasKey(
            //    hourlySales => new { hourlySales.CookieStandId,hourlySales.Hour, hourlySales.SalesPerHour }
            //    );

            //modelBuilder.Entity<HourlySales>().HasData(
            //new HourlySales() { CookieStandId = 1,Hour=1,SalesPerHour=1 }
            //);


            base.OnModelCreating(modelBuilder);
        }

    }
}
