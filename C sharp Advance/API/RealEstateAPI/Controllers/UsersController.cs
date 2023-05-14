using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RealEstateAPI.Data;
using RealEstateAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        APIDbContext _dbcontext = new APIDbContext();
        // let us use all the fucntionalities of appsettings.json file
        private IConfiguration _config;

        public UsersController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("[action]")]
        public IActionResult Register([FromBody] User user)
        {
            var userExists = _dbcontext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userExists != null) 
            {
                // either one is working fine
                return BadRequest("User with this email already exists");
                /*return StatusCode(StatusCodes.Status400BadRequest);*/
            }
            else
            {
                _dbcontext.Users.Add(user);
                _dbcontext.SaveChanges();
                // status code for creating is 201
                return StatusCode(StatusCodes.Status201Created);
            }
        }
        [HttpGet]
        public IEnumerable<User> ShowUsers()
        {
            return _dbcontext.Users;
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromBody] User user)
        {
            var currUser = _dbcontext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (currUser == null) 
            {
                return NotFound();
            }
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            // hashing our security key
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            // payloads
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            // generating the JWT token
            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(60),
                signingCredentials:credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt);
        }
    }
}
