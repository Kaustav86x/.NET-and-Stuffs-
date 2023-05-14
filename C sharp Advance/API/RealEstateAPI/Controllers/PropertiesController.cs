using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstateAPI.Data;
using RealEstateAPI.Models;
using System.Security.Claims;

namespace RealEstateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        APIDbContext _dbcontext = new APIDbContext();

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody]Property property) 
        {
            if(property == null) 
            {
                return NoContent();
            }
            else
            {
                var userEmail = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var user = _dbcontext.Users.FirstOrDefault(e => e.Email == userEmail);
                if(user == null) return NotFound();
                property.IsTrending = false;
                property.UserId = user.Id;
                _dbcontext.Properties.Add(property);
                _dbcontext.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
        }

        /*[HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] Property property)
        {
            // check this id is present or not
            var propertyResult = _dbcontext.Properties.FirstOrDefault(u => u.Id == id);
            if(propertyResult == null)
                return NotFound();
            else
            {
                var userEmail = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var user = _dbcontext.Users.FirstOrDefault(e => e.Email == userEmail);
                if (user == null) return NotFound();
                if (propertyResult.UserId == user.Id)
                {
                    propertyResult.Name = property.Name;
                    propertyResult.Details = property.Details;
                    propertyResult.Price = property.Price;
                    propertyResult.Address = property.Address;
                    property.IsTrending = false;
                    // foreign key (user table)
                    property.UserId = user.Id;

                    *//*_dbcontext.Properties.Add(property);*//*
                    _dbcontext.SaveChanges();
                    return Ok("Data updated successfully!");
                }
                else
                    return BadRequest();
            }
        }*/
    }
}
