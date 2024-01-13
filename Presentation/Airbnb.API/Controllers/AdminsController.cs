using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public AdminsController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins()
        {
            var admins = await _context.Admins.FromSqlRaw("SELECT * FROM admin").ToListAsync();
            return Ok(admins);
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admins.FromSqlRaw("SELECT * FROM admin WHERE admin_id = {0}", id).FirstOrDefaultAsync();
            
            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // GET: api/Admins/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetAdminsCount()
        {
            var admins = await _context.Admins.FromSqlRaw("SELECT * FROM admin").ToListAsync();
            var count = admins.Count;
            return Ok(count);
        }

        // POST: api/Admins
        [HttpPost]
        public async Task<ActionResult<Admin>> PostAdmin(Admin admin)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO admin (password, owner_id, name, email_verified_at, created_at, remember_token, phone_num, description, email, updated_at) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9})",
                admin.password, admin.owner_id, admin.name, admin.email_verified_at, admin.created_at, admin.remember_token, admin.phone_num, admin.description, admin.email, admin.updated_at);

            return CreatedAtAction(nameof(GetAdmin), new { id = admin.admin_id }, admin);
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin(int id, Admin admin)
        {
            // Use raw SQL to update specific properties of the admin
            await _context.Database.ExecuteSqlRawAsync("UPDATE admin SET name = {0}, email = {1}, phone_num = {2}, description = {3} WHERE admin_id = {4}",
                admin.name, admin.email, admin.phone_num, admin.description, id);

            return NoContent();

        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("UPDATE rooms SET admin_id = -1 WHERE admin_id = {0}", id);

            await _context.Database.ExecuteSqlRawAsync("DELETE FROM admin WHERE admin_id = {0}", id);

            return NoContent();
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.FromSqlRaw("SELECT * FROM admin WHERE admin_id = {0}", id).Any();
        }
    }
}
