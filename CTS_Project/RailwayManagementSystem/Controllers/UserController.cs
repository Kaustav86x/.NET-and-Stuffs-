using Microsoft.AspNetCore.Http;
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
            if(doesExists != null) 
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
        public IActionResult Login([FromBody] string Email,string Password)
        {
            var exists = _Railwaycontext.Users.FirstOrDefault(e => e.Email.Equals(Email) && e.Password.Equals(Password));
            if (exists == null)
            {
                return NotFound("User not found");
            }
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            string roleType = "";
            foreach(var role in _Railwaycontext.Roles) 
            {
                if (role.Id == exists.Role_id)
                    roleType = role.Role_type;
                break;
            }
            // claimType, claimValue
            var EmailClaim = new Claim(ClaimTypes.Email, Email);
            var userClaim = new Claim(ClaimTypes.Role, roleType);

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

        /*[HttpPost("[action]")]
        public IActionResult Logout()
        {

        }*/


    }
    }
