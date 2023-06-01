using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RailwayDbContext _context;
        private readonly IConfiguration _confih;

        public UserController(RailwayDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'RailwayDbContext.Users'  is null.");
          }
            _context.Users.Add(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserExists(user.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
 /*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        RailwayDbContext _Railwaycontext = new RailwayDbContext();
        private IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("[action]")]
        // admin registration
        public IActionResult RegisterAdmin([FromBody] User user)
        {
            var doesExists = _Railwaycontext.Users.FirstOrDefault(e => e.Email == user.Email);
            if (doesExists != null)
            {
                return BadRequest("User with the same Email already exist");
            }
            // for admin
            user.Role_id = "A";
            _Railwaycontext.Users.Add(user);
            _Railwaycontext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("[action]")]
        // passenger/normal user registration
        public IActionResult RegisterPassenger([FromBody] User user)
        {
            var doesExists = _Railwaycontext.Users.FirstOrDefault(e => e.Email == user.Email);
            if (doesExists != null)
            {
                return BadRequest("User with the same Email already exist");
            }
            // for normal user
            user.Role_id = "P";
            _Railwaycontext.Users.Add(user);
            _Railwaycontext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("[action]")]
        public IActionResult Login(string Email, string Password)
        {
            var exists = _Railwaycontext.Users.FirstOrDefault(e => e.Email == Email && e.Password == Password);
            if (exists == null)
            {
                return NotFound("User not found");
            }
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var role = _Railwaycontext.Roles.Find(exists.Role_id);
            /*foreach(var role in _Railwaycontext.Roles) 
            {
                if (role.Id == exists.Role_id)
                    roleType = role.Role_type;
                break;
            }

            // claimType, claimValue
            var EmailClaim = new Claim(ClaimTypes.Email, Email);
            var userClaim = new Claim(ClaimTypes.Role, role.Role_type);

            var claims = new[]
            {
                EmailClaim, userClaim
            };

            // generating the JWT token
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt);
        }


    }
}
 */

