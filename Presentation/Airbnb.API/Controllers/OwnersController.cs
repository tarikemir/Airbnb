using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public OwnersController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Owners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            var owners = await _context.Owners.FromSqlRaw("SELECT * FROM owner").ToListAsync();
            return Ok(owners);
        }

        // GET: api/Owners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var owner = await _context.Owners.FromSqlRaw("SELECT * FROM owner WHERE id = {0}", id).FirstOrDefaultAsync();

            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        // GET: api/Owners/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetOwnersCount()
        {
            var owners = await _context.Owners.FromSqlRaw("SELECT * FROM owner").ToListAsync();
            var count = owners.Count;
            return Ok(count);
        }

        // POST: api/Owners
        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO owner (password, name, email_verified_at, created_at, remember_token, phone_num, description, email, updated_at) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                owner.password, owner.name, owner.email_verified_at, owner.created_at, owner.remember_token, owner.phone_num, owner.description, owner.email, owner.updated_at);

            return CreatedAtAction(nameof(GetOwner), new { id = owner.id }, owner);
        }

        // PUT: api/Owners/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {

            // Use raw SQL to update the owner
            await _context.Database.ExecuteSqlRawAsync("UPDATE owner SET name = {0}, email = {1}, phone_num = {2}, description = {3} WHERE id = {4}",
                owner.name, owner.email, owner.phone_num, owner.description, id);

            return NoContent();

        }

        // DELETE: api/Owners/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM owner WHERE id = {0}", id);

            return NoContent();
        }

        private bool OwnerExists(int id)
        {
            return _context.Owners.FromSqlRaw("SELECT * FROM owner WHERE id = {0}", id).Any();
        }
    }

}
