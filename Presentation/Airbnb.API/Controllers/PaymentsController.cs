using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public PaymentsController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            var payments = await _context.Payments.FromSqlRaw("SELECT * FROM payment").ToListAsync();
            return Ok(payments);
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            var payment = await _context.Payments.FromSqlRaw("SELECT * FROM payment WHERE payment_id = {0}", id).FirstOrDefaultAsync();

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        // GET: api/Payments/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetPaymentsCount()
        {
            var payments = await _context.Payments.FromSqlRaw("SELECT * FROM payment").ToListAsync();
            var count = payments.Count;
            return Ok(count);
        }

        // POST: api/Payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO payment (reservation_id, status, credit_card_number, credit_card_CCV, card_expiration_date, name, surname, billing_address) " +
                "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})",
                payment.reservation_id, payment.status, payment.credit_card_number, payment.credit_card_CCV, payment.card_expiration_date, payment.name, payment.surname, payment.billing_address);

            return CreatedAtAction(nameof(GetPayment), new { id = payment.payment_id }, payment);
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            // Use raw SQL to update specific properties of the payment
            await _context.Database.ExecuteSqlRawAsync("UPDATE payment SET status = {0}, credit_card_number = {1}, credit_card_CCV = {2}, card_expiration_date = {3}, name = {4}, surname = {5}, billing_address = {6} WHERE payment_id = {7}",
                payment.status, payment.credit_card_number, payment.credit_card_CCV, payment.card_expiration_date, payment.name, payment.surname, payment.billing_address, id);

            return NoContent();

        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM payment WHERE id = {0}", id);

            return NoContent();
        }

        private bool PaymentExists(int id)
        {
            return _context.Payments.FromSqlRaw("SELECT * FROM payment WHERE payment_id = {0}", id).Any();
        }
    }
}
