namespace cookie_stand_api.Models.Interface
{
    public interface ICookieStand
    {
        // CREATE
        Task<CookieStand> Create(CookieStand cookieStand);

        // GET ALL
        Task<List<CookieStand>> GetAll();

        // GET ONE BY ID
        Task<CookieStand> GetById(int id);

        // UPDATE
        Task<CookieStand> Update(int id, CookieStand cookieStand);

        // DELETE
        Task Delete(int id);
    }
}
