using cookie_stand_api.Models.Dtos;

namespace cookie_stand_api.Models.Interface
{
    public interface ICookieStand
    {
        Task<CookieStandViewDto> Create(CookieStandDto cookieStand);

        Task<IEnumerable<CookieStandViewDto>> GetAll();

        Task<CookieStandViewDto> GetById(int id);

        Task Delete(int id);

        Task<CookieStand> Update(int id, CookieStandDto updatedCookieStand);
    }
}
