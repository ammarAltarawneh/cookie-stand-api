namespace cookie_stand_api.Models
{
    public class HourlySales
    {

        public int Id { get; set; }

        public int StandCookieId { get; set; }

        public int salesvalue { get; set; }

        public CookieStand cookieStand { get; set; }
    }
}
