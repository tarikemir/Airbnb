using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentersController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public RentersController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Renters
        [HttpGet]
        public async Task<IActionResult> GetRenters()
        {
            var renters = await _context.Renters.FromSqlRaw("SELECT * FROM renter").ToListAsync();
            return Ok(renters);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetOwnersCount()
        {
            var renters = await _context.Renters.FromSqlRaw("SELECT * FROM renter").ToListAsync();
            var count = renters.Count;
            return Ok(count);
        }
        // GET: api/Renters/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRenter(int id)
        {
            var renter = await _context.Renters.FromSqlRaw("SELECT * FROM renter WHERE renter_id = {0}", id).FirstOrDefaultAsync();

            if (renter == null)
            {
                return NotFound();
            }

            return Ok(renter);
        }

        // POST: api/Renters
        [HttpPost]
        public async Task<IActionResult> PostRenter([FromBody] Renter renter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _context.Database.ExecuteSqlRawAsync("INSERT INTO renter (email, password, remember_token, name, created_at, phone_number, description, email_verified_at) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                renter.email, renter.password, renter.remember_token, renter.name, renter.created_at, renter.phone_number, renter.description, renter.email_verified_at);

            return CreatedAtAction("GetRenter", new { id = renter.renter_id }, renter);
        }

        // PUT: api/Renters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRenter(int id, [FromBody] Renter renter)
        {
            // Use raw SQL to update specific properties of the renter
            await _context.Database.ExecuteSqlRawAsync("UPDATE renter SET email = {0}, password = {1}, remember_token = {2}, name = {3}, created_at = {4}, phone_number = {5}, description = {6}, email_verified_at = {7} WHERE renter_id = {8}",
                renter.email, renter.password, renter.remember_token, renter.name, renter.created_at, renter.phone_number, renter.description, renter.email_verified_at, id);

            return NoContent();

        }

        // DELETE: api/Renters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRenter(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM renter WHERE id = {0}", id);

            return NoContent();
        }
    }
}
