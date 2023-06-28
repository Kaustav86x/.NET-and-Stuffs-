using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using RailwayManagementSystem.Data;
using RailwayManagementSystem.Models.AddModels;
using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RailwayDbContext _RailwayDbContext;

        public RoleController(RailwayDbContext context)
        {
            _RailwayDbContext = context;
        }

        // GET: api/Role
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetRoles()
        {
          if (_RailwayDbContext.Roles == null)
          {
              return NoContent();
          }
            return Ok(await _RailwayDbContext.Roles.ToListAsync());
        }

        // GET: api/Role/5
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> GetRolesById(string id)
        {
          if (_RailwayDbContext.Roles == null)
          {
              return NoContent();
          }
            var role = await _RailwayDbContext.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound("No roles found with this Id");
            }

            return Ok(role.Role_Type);
        }

        // PUT: api/Role/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> UpdateRoles(string id, AddRoles role)
        {
            var r = await _RailwayDbContext.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (id != role.Id)
            {
                return BadRequest("Role Id doesn't match");
            }
            if (r == null)
                return BadRequest("Id is not valid");
            if (id == "A" || id == "P")
                return BadRequest("Admin Role or Passenger Role can't be updated");
            r.Id = id;
            r.Role_Type = role.Role_type;
            await _RailwayDbContext.SaveChangesAsync();
            return Ok("Role Id updated successfully");
        }

        // POST: api/Role
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> AddRoles(AddRoles role)
        {
          if (_RailwayDbContext.Roles == null)
              return Problem("There are no existing roles");
            var roles = _RailwayDbContext.Roles.FirstOrDefaultAsync(r => r.Id == role.Id && r.Role_Type == role.Role_type);
            if(roles == null)
            {
                var r = new Role()
                {
                    Id = role.Id,
                    Role_Type = role.Role_type,
                };
                await _RailwayDbContext.Roles.AddAsync(r);
                await _RailwayDbContext.SaveChangesAsync();
                return Created("201","New Role is created");
            }
            return BadRequest("Role Id and Role_Type already exists");
        }

        // DELETE: api/Role/5
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("[action]")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (_RailwayDbContext.Roles == null)
            {
                return NoContent();
            }
            var role = await _RailwayDbContext.Roles.FirstOrDefaultAsync(a => a.Id == id);
            if (id == "A" || id == "P")
                return BadRequest("Admin Role or Passenger Role can't be deleted");
            else
            {
                if (role == null)
                {
                    return NotFound("Role with this id is not found");
                }
                _RailwayDbContext.Roles.Remove(role);
                await _RailwayDbContext.SaveChangesAsync();
                return Ok("Role successfully deleted");
            }
        }
    }
}
