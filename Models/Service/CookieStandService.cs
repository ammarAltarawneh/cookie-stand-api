using cookie_stand_api.Data;
using cookie_stand_api.Models.Dtos;
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

        public async Task<CookieStandViewDto> Create(CookieStandDto cookieStand)
        {
            var cooke = new CookieStand()
            {
                Location = cookieStand.Location,
                Description = cookieStand.Description,
                MinimumCustomersPerHour = cookieStand.MinimumCustomersPerHour,
                MaximumCustomersPerHour = cookieStand.MaximumCustomersPerHour,
                AverageCookiesPerSale = cookieStand.AverageCookiesPerSale,
                Owner = cookieStand.Owner
            };

            await _context.cookieStands.AddAsync(cooke);
            await _context.SaveChangesAsync();

            int max = (int)(cookieStand.MaximumCustomersPerHour * cookieStand.AverageCookiesPerSale);
            int min = (int)(cookieStand.MinimumCustomersPerHour * cookieStand.AverageCookiesPerSale);
            int diff = max - min;

            List<HourlySales> hours = new List<HourlySales>();

            var random = new Random();

            for (int i = 0; i < 14; i++)
            {
                var hourlySale = new HourlySales()
                {
                    StandCookieId = cooke.Id,
                    salesvalue = random.Next(min, max),
                };

                hours.Add(hourlySale);
            }

            cooke.hourlySale = hours;

            await _context.SaveChangesAsync();

            // Return the created CookieStand record
            var newcooke = new CookieStandViewDto()
            {
                Id = cooke.Id,
                Location = cooke.Location,
                Description = cooke.Description,
                MaximumCustomersPerHour = cooke.MaximumCustomersPerHour,
                MinimumCustomersPerHour = cooke.MinimumCustomersPerHour,
                AverageCookiesPerSale = cooke.AverageCookiesPerSale,
                Owner = cooke.Owner,
            };

            List<int> h = new List<int>();

            foreach (var item in cooke.hourlySale)
            {
                h.Add(item.salesvalue);
            }

            newcooke.hourlySale = h;

            return newcooke;

        }


        public async Task Delete(int id)
        {
            var cookieStand = _context.cookieStands.Find(id);


            _context.cookieStands.Remove(cookieStand);


            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CookieStandViewDto>> GetAll()
        {
            var all = await _context.cookieStands
                .Include(c => c.hourlySale)
                .ToListAsync();

            List<CookieStandViewDto> alllist = new List<CookieStandViewDto>();

            foreach (var cookieStand in all)
            {
                var stands = await GetById(cookieStand.Id);

                alllist.Add(stands);
            }

            return alllist;
        }

        public async Task<CookieStandViewDto> GetById(int id)
        {

            var cooke = await _context.cookieStands
                .Include(c => c.hourlySale)
                .FirstOrDefaultAsync(c => c.Id == id);

            var newcooke = new CookieStandViewDto()
            {
                Id = cooke.Id,
                Location = cooke.Location,
                Description = cooke.Description,
                MaximumCustomersPerHour = cooke.MaximumCustomersPerHour,
                MinimumCustomersPerHour = cooke.MinimumCustomersPerHour,
                AverageCookiesPerSale = cooke.AverageCookiesPerSale,
                Owner = cooke.Owner,
            };

            List<int> h = new List<int>();

            foreach (var item in cooke.hourlySale)
            {
                h.Add(item.salesvalue);
            }

            newcooke.hourlySale = h;

            return newcooke;

        }

        public async Task<CookieStand> Update(int id, CookieStandDto updatedCookieStand)
        {
            var cookieStand = await _context.cookieStands
                .Include(c => c.hourlySale)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cookieStand != null)
            {
                cookieStand.Location = updatedCookieStand.Location;
                cookieStand.Description = updatedCookieStand.Description;
                cookieStand.MinimumCustomersPerHour = updatedCookieStand.MinimumCustomersPerHour;
                cookieStand.MaximumCustomersPerHour = updatedCookieStand.MaximumCustomersPerHour;
                cookieStand.AverageCookiesPerSale = updatedCookieStand.AverageCookiesPerSale;
                cookieStand.Owner = updatedCookieStand.Owner;

                int max = (int)(cookieStand.MaximumCustomersPerHour * cookieStand.AverageCookiesPerSale);
                int min = (int)(cookieStand.MinimumCustomersPerHour * cookieStand.AverageCookiesPerSale);
                int diff = max - min;



                var random = new Random();


                foreach (var item in cookieStand.hourlySale)
                {
                    item.salesvalue = random.Next(min, max);
                }




                await _context.SaveChangesAsync();
            }

            return cookieStand;
        }
    }
}
