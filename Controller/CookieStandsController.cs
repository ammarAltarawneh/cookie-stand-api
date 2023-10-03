using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Models;
using cookie_stand_api.Models.Interface;
using cookie_stand_api.Models.Service;

namespace cookie_stand_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _context;
        public CookieStandsController(ICookieStand cookieStand)
        {
            _context = cookieStand;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CookieStand>>> GetAll()
        {
            var CookieStands = await _context.GetAll();
            if (CookieStands == null)
            {
                return NotFound();
            }
            return CookieStands;
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStand>> GetCookieStand(int id)
        {
            var cookieStand = await _context.GetById(id);
            if (cookieStand == null)
            {
                return NotFound();
            }

            return cookieStand;
        }

        // PUT: api/CookieStands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCookieStand(int id, CookieStand updatedCookieStand)
        {
            if (id != updatedCookieStand.Id)
            {
                return BadRequest();
            }
            var cookieStand = await _context.Update(id, updatedCookieStand);
            if (cookieStand == null)
            {
                return NotFound();
            }
            return Ok(cookieStand);
        }

        // POST: api/CookieStands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand(CookieStand cookieStand)
        {
            await _context.Create(cookieStand);
            return CreatedAtAction("GetCookieStand", new { id = cookieStand.Id }, cookieStand);
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCookieStand(int id)
        {
            await _context.Delete(id);

            return NoContent();
        }
    }
}
