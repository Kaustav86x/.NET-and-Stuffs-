using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models;
using RailwayManagementSystem.Models.AddModels;
using RailwayManagementSystem.Models.DbModels;
using RailwayManagementSystem.Models.ViewModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RailwayDbContext _Railwaycontext;
        private readonly IConfiguration _config;

        public UserController(RailwayDbContext context, IConfiguration config)
        {
            _Railwaycontext = context;
            this._config = config;
        }

        // GET: api/User
        // Get the list of the Passemegrs from the database
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[Action]")]
        public async Task<ActionResult> GetPassengers()
        {
            if (_Railwaycontext.Users == null)
            {
                return NotFound("No passengers found");
            }
            return Ok(await _Railwaycontext.Users.ToListAsync());
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // get passenger by ID
        [HttpGet]
        [Authorize(Roles = "Admin,Passenger")]
        [Route("[Action]/{id}")]
        public async Task<IActionResult> GetPassengerId(string pass_id)
        {
            if (_Railwaycontext.Users == null)
            {
                return BadRequest("No passenger found with this Id");
            }

            return Ok(await _Railwaycontext.Users.Where(pass => pass.Id == pass_id).ToListAsync());
        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // finding user details of a certain user using Id
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]/{id:string")]
        public async Task<ActionResult> GetUserDetailsById([FromRoute] string user_id)
        {
            var user = await _Railwaycontext.Users.FindAsync(user_id);
            if (user != null)
            {
                var viewPassenger = new ViewUser()
                {
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Phone = user.Phone,
                    Email = user.Email,
                    Role = user.Role_id
                };
                return Ok(viewPassenger);
            }
            else
                return NotFound("Passenger not found");
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        /*public async Task<IActionResult> DeleteUser(string id)
        {
           
        }*/
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action/{id:string}")]
        public async Task<IActionResult> UpdatePassengers([FromBody] string uid, [FromBody] ViewUser passenger)
        {
            var PassengerExists = await _Railwaycontext.Users.FindAsync(uid);
            if (PassengerExists != null)
            {
                PassengerExists.Fname = passenger.Fname;
                PassengerExists.Lname = passenger.Lname;
                PassengerExists.Phone = passenger.Phone;
                PassengerExists.Email = passenger.Email;
                PassengerExists.Role_id = passenger.Role;

                await _Railwaycontext.SaveChangesAsync();
                return Ok("Record updated successfully");
            }
            else { return NotFound("Passenger with that Id is not found"); }
        }
        // new user addition
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp([FromBody] User passenger)
        {
            var email = await _Railwaycontext.Users.FindAsync(passenger.Email);
            if (email != null)
            {
                return Ok("EmailId already exists !");
            }
            else
            {
                /*[Authorize]*/
                // string role = passenger.Role_id; // A / P
                _Railwaycontext.Users.Add(passenger);
                _Railwaycontext.SaveChanges();
                return Ok("New User added successfully");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] Login User)
        {
            var ExistingUser = _Railwaycontext.Users.FirstOrDefault(e => e.Email == User.Email);
            if (ExistingUser != null)
            {
                if (User.Password == ExistingUser.Password)
                {
                    var role = await _Railwaycontext.Roles.FindAsync(ExistingUser.Role_id);
                    var jwt = JwtTokenCreation(ExistingUser.Email, role.Role_type);
                    return Ok(jwt);
                }
                return BadRequest("Password is incorrect");
            }
            else { return NotFound("Incorrect Email Id"); }
        }
        private string JwtTokenCreation(string Email, string role)
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            // claimType, claimValue
            var EmailClaim = new Claim(ClaimTypes.Email, Email);
            var userClaim = new Claim(ClaimTypes.Role, role);

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
            return jwt;
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

