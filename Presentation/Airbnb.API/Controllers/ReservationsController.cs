using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public ReservationsController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservations()
        {
            var reservations = await _context.Reservations.FromSqlRaw("SELECT * FROM reservation").ToListAsync();
            return Ok(reservations);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            var reservation = await _context.Reservations.FromSqlRaw("SELECT * FROM reservation WHERE reservation_id = {0}", id).FirstOrDefaultAsync();

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // GET: api/Reservations/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetReservationsCount()
        {
            var reservations = await _context.Reservations.FromSqlRaw("SELECT * FROM reservation").ToListAsync();
            var count = reservations.Count;
            return Ok(count);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO reservation (renter_id, end_date, start_date, room_id, updated_at, total, unit_price, owner_id) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                reservation.renter_id, reservation.end_date, reservation.start_date, reservation.room_id, reservation.updated_at, reservation.total, reservation.unit_price, reservation.owner_id);

            return CreatedAtAction(nameof(GetReservation), new { id = reservation.reservation_id }, reservation);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            // Use raw SQL to update specific properties of the reservation
            await _context.Database.ExecuteSqlRawAsync("UPDATE reservation SET end_date = {0}, start_date = {1}, total = {2}, unit_price = {3} WHERE reservation_id = {4}",
                reservation.end_date, reservation.start_date, reservation.total, reservation.unit_price, id);

            return NoContent();
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM reservation WHERE id = {0}", id);

            return NoContent();
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservations.FromSqlRaw("SELECT * FROM reservation WHERE reservation_id = {0}", id).Any();
        }
    }
}
