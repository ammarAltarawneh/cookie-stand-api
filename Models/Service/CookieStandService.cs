using cookie_stand_api.Data;
using cookie_stand_api.Models.Interface;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Models.Service
{
    public class CookieStandService : ICookieStand
    {
        private readonly AppDbContext _context;

        public CookieStandService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CookieStand> Create(CookieStand cookieStand)
        {
            await _context.AddAsync(cookieStand);
            await _context.SaveChangesAsync();
            return cookieStand;
        }

        public async Task Delete(int id)
        {
            var cookieStand = await _context.cookieStands.FindAsync(id);
            if (cookieStand != null)
            {
                _context.cookieStands.Remove(cookieStand);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<CookieStand>> GetAll()
        {
            //var cookieStands = await _context.cookieStands.Select(cookieStand => new CookieStand
            //{
            //    Id = cookieStand.Id,
            //    Location = cookieStand.Location,
            //    Description = cookieStand.Description,
            //    MinimumCustomersPerHour = cookieStand.MinimumCustomersPerHour,
            //    MaximumCustomersPerHour = cookieStand.MaximumCustomersPerHour,
            //    AverageCookiesPerSale = cookieStand.AverageCookiesPerSale,
            //    Owner = cookieStand.Owner,
            //    HourlySales = cookieStand.HourlySales.Select(HR => new HourlySales
            //    {                    
            //        SalesPerHour = HR.SalesPerHour,
            //    }).ToList()

            //}).ToListAsync();
            //return cookieStands;
            return await _context.cookieStands.ToListAsync();
        }

        public async Task<CookieStand> GetById(int id)
        {
            //var cookieStand = await _context.cookieStands.Select(cookieStand => new CookieStand
            //{
            //    Id = cookieStand.Id,
            //    Location = cookieStand.Location,
            //    Description = cookieStand.Description,
            //    MinimumCustomersPerHour = cookieStand.MinimumCustomersPerHour,
            //    MaximumCustomersPerHour = cookieStand.MaximumCustomersPerHour,
            //    AverageCookiesPerSale = cookieStand.AverageCookiesPerSale,
            //    Owner = cookieStand.Owner,
            //    HourlySales = cookieStand.HourlySales.Select(HR => new HourlySales
            //    {
            //        SalesPerHour = HR.SalesPerHour,
            //    }).ToList()

            //}).FirstOrDefaultAsync(h => h.Id == id); ;
            //return cookieStand;
            return await _context.cookieStands.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CookieStand> Update(int id, CookieStand updatedCookieStand)
        {
            var cookieStand = await _context.cookieStands.FirstOrDefaultAsync(c => c.Id == id);
            if (cookieStand != null)
            {
                cookieStand.Location = updatedCookieStand.Location;
                cookieStand.Description = updatedCookieStand.Description;
                cookieStand.MinimumCustomersPerHour = updatedCookieStand.MinimumCustomersPerHour;
                cookieStand.MaximumCustomersPerHour = updatedCookieStand.MaximumCustomersPerHour;
                cookieStand.AverageCookiesPerSale = updatedCookieStand.AverageCookiesPerSale;
                cookieStand.Owner = updatedCookieStand.Owner;
                cookieStand.Hourly_Sales = updatedCookieStand.Hourly_Sales;

                _context.SaveChanges();
            }
            return cookieStand;
        }
    }
}
