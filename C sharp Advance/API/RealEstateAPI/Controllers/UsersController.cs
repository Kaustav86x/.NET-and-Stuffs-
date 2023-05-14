using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        APIDbContext _dbcontext = new APIDbContext();

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

    }
}
