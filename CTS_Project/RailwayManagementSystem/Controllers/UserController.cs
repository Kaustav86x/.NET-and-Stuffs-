using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.AddModels;
using RailwayManagementSystem.Models.DbModels;
using RailwayManagementSystem.Models.ViewModels;
using RailwayManagementSystem.Star_Methods;

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

        // EncryptionMethod hashvalue = new EncryptionMethod();

        // GET: api/User
        // Get the list of the Passemegrs from the database
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[Action]")]
        public async Task<IActionResult> GetPassengers()
        {
            if (_Railwaycontext.Users == null)
            {
                return NotFound("No passengers found");
            }
            return Ok(await _Railwaycontext.Users.ToListAsync());
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Passenger")]
        [Route("[action]")]
        public async Task<IActionResult> GetUserDetailsById(string userId)
        {
            var user = await _Railwaycontext.Users.FindAsync(userId);
            if (user != null)
            {
                var viewPassenger = new ViewUser()
                {
                    Id = userId,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Phone = user.Phone,
                    Email = user.Email,
                    Role = user.RoleId
                };
                return Ok(viewPassenger);
            }
            else
                return NotFound("User not found");
        }

        // DELETE: api/User/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _Railwaycontext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User Id not Find");
            }
            _Railwaycontext.Remove(user);
            await _Railwaycontext.SaveChangesAsync();
            return Ok("User successfully deleted");
        }
        [HttpPut]
        [Authorize(Roles = "Admin,Passenger")]
        [Route("[action]")]
        public async Task<IActionResult> UpdatePassengers(string uid,AddUser passenger)
        {
            var PassengerExists = await _Railwaycontext.Users.FindAsync(uid);
            if (PassengerExists != null)
            {
                PassengerExists.Fname = passenger.Fname;
                PassengerExists.Lname = passenger.Lname;
                PassengerExists.Phone = passenger.Phone;
                PassengerExists.Email = passenger.Email;
                PassengerExists.RoleId = passenger.Role;

                await _Railwaycontext.SaveChangesAsync();
                return Ok("Record updated successfully");
            }
            else { return NotFound("Passenger with that Id is not found"); }
        }
        // new user addition
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SignUp(string roleId, [FromBody] AddUser pass)
        {
            // EncryptionMethod hashvalue = new EncryptionMethod();
            var ExistsUser = await _Railwaycontext.Users.FirstOrDefaultAsync(r => r.Email == pass.Email);
            // var existemail = await _Railwaycontext.Users.FindAsync(pass.Email);
            if (ExistsUser == null)
            {
                var addUser = new User()
                {
                    Id = pass.Id,
                    Fname = pass.Fname,
                    Lname = pass.Lname,
                    Phone = pass.Phone,
                    Email = pass.Email,
                    Password = pass.Password,
                    RoleId = pass.Role
                };
                await _Railwaycontext.Users.AddAsync(addUser);
                await _Railwaycontext.SaveChangesAsync();
                return Ok("User Registration successful");
            }
            return BadRequest("User with this email already exists");
        }

            [HttpPost("[action]")]
        public async Task<IActionResult> Login(Login User)
        {
            EncryptionMethod hashvalue = new EncryptionMethod();
            var ExistingUser = _Railwaycontext.Users.FirstOrDefault(e => e.Email == User.Email);
            if (ExistingUser != null)
            {
                // checking if the current user having the same hashed encrypted password or not
                if (hashvalue.EncryptString(User.Password) == hashvalue.EncryptString(ExistingUser.Password))
                {
                    var role = await _Railwaycontext.Roles.FindAsync(ExistingUser.RoleId);
                    var jwt = JwtTokenCreation(ExistingUser.Email, role.Role_Type);
                    return Ok(new { Token = jwt});
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
 

