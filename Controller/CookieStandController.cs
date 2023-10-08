using cookie_stand_api.Models;
using cookie_stand_api.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cookie_stand_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandController : ControllerBase
    {
        private readonly ICookieStand _cookieStand;
        public CookieStandController(ICookieStand cookieStand)
        {
            _cookieStand = cookieStand;
        }

        // GET: api/CookieStands
        [HttpGet]
        [Route("/CookieStands")]
        public async Task<ActionResult<IEnumerable<CookieStand>>> GetAll()
        {
            var CookieStands = await _cookieStand.GetAll();
            if (CookieStands == null)
            {
                return NotFound();
            }
            return CookieStands;
        }


    }
}
