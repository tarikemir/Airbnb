using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public RoomsController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            var rooms = await _context.Rooms.FromSqlRaw("SELECT * FROM rooms").ToListAsync();
            return Ok(rooms);
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await _context.Rooms.FromSqlRaw("SELECT * FROM rooms WHERE room_id = {0}", id).FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // GET: api/Rooms/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetRoomsCount()
        {
            var rooms = await _context.Rooms.FromSqlRaw("SELECT * FROM rooms").ToListAsync();
            var count = rooms.Count;
            return Ok(count);

        }

        // POST: api/Rooms
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO rooms (updated_at, created_at, price, summary, address, home_type, room_type, status, total_bedrooms, total_bathrooms, admin_id, admin_verification, longitude, has_heating, latitude, has_tv, has_internet, has_air_con, owner_id) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18})",
                room.updated_at, room.created_at, room.price, room.summary, room.address, room.home_type, room.room_type, room.status, room.total_bedrooms, room.total_bathrooms, room.admin_id, room.admin_verification, room.longitude, room.has_heating, room.latitude, room.has_tv, room.has_internet, room.has_air_con, room.owner_id);

            return CreatedAtAction(nameof(GetRoom), new { id = room.room_id }, room);
        }

        // PUT: api/Rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            // Use raw SQL to update specific properties of the room
            await _context.Database.ExecuteSqlRawAsync("UPDATE rooms SET price = {0}, summary = {1}, address = {2}, home_type = {3}, room_type = {4}, status = {5}, total_bedrooms = {6}, total_bathrooms = {7} WHERE room_id = {8}",
                room.price, room.summary, room.address, room.home_type, room.room_type, room.status, room.total_bedrooms, room.total_bathrooms, id);

            return NoContent();
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM rooms WHERE id = {0}", id);

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.FromSqlRaw("SELECT * FROM rooms WHERE room_id = {0}", id).Any();
        }
    }
}
