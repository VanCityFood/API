using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using VanCityFood.Models;

namespace VanCityFood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IContext _context;

        public RestaurantController(IContext context )
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetAllRestaurantsAsync()
        {
            if(_context.Restaurants == null)
            {
                return BadRequest();
            }

            return await _context.Restaurants.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurantById(int id)
        {
            
            var restaurant = await _context.Restaurants.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        [HttpPost] 
        public async Task<ActionResult<Restaurant>> AddRestaurantToDatabase(Restaurant restaurant)
        {
            if(_context.Restaurants == null)
            {
                return BadRequest();
            }
            _context.Restaurants.Add(restaurant);
            await _context.CommitChangesAsync();
            return CreatedAtAction(nameof(GetRestaurantById), new {id = restaurant.Id}, restaurant);
        }

    }
}
