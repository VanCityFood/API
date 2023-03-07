using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VanCityFood.Models;

namespace VanCityFood.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserReviewController : ControllerBase
    {
        private readonly IContext _context;

        public UserReviewController(IContext context)
        {
            _context = context;
        }  

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReview>> GetReviewById(int id)
        {
            if(_context.UserReviews == null)
            {
                return BadRequest();
            }
            var review = await _context.UserReviews.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }
            return review;

        }

        [HttpGet("restaurant/{id}")]
        public async Task<IEnumerable<UserReview>> GetAllReviewsByRestaurant(Restaurant restaurant)
        {
            var reviews = await _context.UserReviews.Where(r => r.RestId == restaurant.Id).ToListAsync();

            if (reviews.Count == 0)
            {
                return null;
            }
            return reviews;
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<UserReview>>> GetAllReviewsByUser(User user)
        {
            var reviews = await _context.UserReviews.Where(r=> r.UserId == user.Id).ToListAsync(); 

            if (reviews.Count == 0)
            {
                return null;
            }
            return reviews;
        }

        [HttpPost]
        public async Task<ActionResult<UserReview>> AddNewUserReview(UserReview review)
        {
            if(review == null)
            {
                return BadRequest();
            }
            _context.UserReviews.Add(review);
            await _context.CommitChangesAsync();

            return CreatedAtAction(nameof(GetReviewById), new { id = review.Id }, review);

        }

        
    }
}
