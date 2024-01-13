using Airbnb.Domain.Entities;
using Airbnb.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Airbnb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly AirbnbDbContext _context;

        public ReviewsController(AirbnbDbContext context)
        {
            _context = context;
        }

        // GET: api/Reviews
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        {
            var reviews = await _context.Reviews.FromSqlRaw("SELECT * FROM review").ToListAsync();
            return Ok(reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(int id)
        {
            var review = await _context.Reviews.FromSqlRaw("SELECT * FROM review WHERE id = {0}", id).FirstOrDefaultAsync();

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // GET: api/Reviews/count
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetReviewsCount()
        {
            var reviews = await _context.Reviews.FromSqlRaw("SELECT * FROM review").ToListAsync();
            var count = reviews.Count;
            return Ok(count);
        }

        // POST: api/Reviews
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review review)
        {
            await _context.Database.ExecuteSqlRawAsync("INSERT INTO review (reservation_id, rating, comment) " +
                "VALUES ({0}, {1}, {2})",
                review.reservation_id, review.rating, review.comment);

            return CreatedAtAction(nameof(GetReview), new { id = review.id }, review);
        }

        // PUT: api/Reviews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            // Use raw SQL to update specific properties of the review
            await _context.Database.ExecuteSqlRawAsync("UPDATE review SET rating = {0}, comment = {1} WHERE id = {2}",
                review.rating, review.comment, id);

            return NoContent();
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            await _context.Database.ExecuteSqlRawAsync("DELETE FROM review WHERE id = {0}", id);

            return NoContent();
        }

        private bool ReviewExists(int id)
        {
            return _context.Reviews.FromSqlRaw("SELECT * FROM review WHERE id = {0}", id).Any();
        }
    }
}
