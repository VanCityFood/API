using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using VanCityFood.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VanCityFood.Controllers
{
    [Route("api/controller/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IContext _context;

        public UserController(IContext context)
        {
            _context = context;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if(!UserExists(id))
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUser(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }
            if(UserExists(user.Id))
            {
                return BadRequest();
            }
            user.Pass = EncryptUserPassword(user.Pass);

            _context.Users.Add(user);
            await _context.CommitChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPost("login")]
        public ActionResult<User> UserLogin(User user)
        {
            if(user == null)
            {
                return BadRequest();
            }

            user.Pass = EncryptUserPassword(user.Pass);

            var currentUser = _context.Users.Where(u => u.Email == user.Email && u.Pass == user.Pass ).FirstOrDefault();

            if(currentUser == null)
            {
                return NotFound();
            }
            return currentUser;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveUserById(int id)
        {
            if(_context.Users == null)
            {
                return BadRequest();
            }
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            await _context.CommitChangesAsync();
            return NoContent();
        }

        private string EncryptUserPassword(string password)
        {
            SHA256 hash = SHA256.Create();
            string salt = "vancityfood";
            string combined = salt+ password+salt;

            byte[] bytes = new byte[combined.Length * sizeof(char)];
            System.Buffer.BlockCopy(combined.ToCharArray(), 0,bytes,0,bytes.Length);

            byte[] result = hash.ComputeHash(bytes);
            string hashedPass = BitConverter.ToString(result).Replace("-", "");

            return hashedPass;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
