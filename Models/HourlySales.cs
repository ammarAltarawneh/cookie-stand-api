namespace cookie_stand_api.Models
{
    public class HourlySales
    {
        
        public int CookieStandId { get; set; } // Foreign Key to CookieStand
        public int Hour { get; set; }
        public int SalesPerHour { get; set; }

        public CookieStand CookieStand { get; set; }
    }
}
